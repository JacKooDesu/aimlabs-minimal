# Mission Template

## 結構範例

```bash
mission
    ├─ main.cts  # 根目錄內的 js 都會被當作 module 載入
    └─ other-actions
        ├─ a.cts
        ├─ b.cts
            .
            .
            .
```

## main.cts

- `configure()` 方法是讓 `ALM` 把內建的服務元件注入到 `core/alm-mission.cts`
- `entry()` 方法會在服務元件註冊後呼叫，如果需要跟 `ALM` 交互，可以考慮將邏輯撰寫在這裡

## [mission-name].json

> 當前版本正在規劃不要使用 json 格式

- 用來讓 ALM 辨識任務內容、敘述、地圖設定等
- 務必依照 `任務資料夾名稱` 命名
- 參數如下：
  - `name` 任務名稱
  - `description` 任務敘述
  - `time_seconds` 任務時間，`<=0` 將不會計時
  - `map` 可加載相對路徑 glb/gltf 模型
  - `map_size` 地圖大小，目前暫時讀取這個值來生成任務房間 (`map` 有值的情況會忽略)
  - `type` 計分類型 (規劃中)
    - `none`
    - `flicking`
    - `reaction`
    - `tracking`
  - `version` 版本，新 API 可能不能兼容
  - `gltf_resources` Json Map 類型，可註冊相對路徑 glb/gltf 模型，使用 `GltfLoaderService.Get(string name)` 在任務腳本中取得模型

## 關於 `Command`

遊戲開發時，物體的位移、轉向與現實中 **連續的作動** 不同，它是 **離散** 的 (根據座標最小間隔)

請看下面這個 `Render Tick`[^1] 的時間軸的呼叫情形：

```text
1 2   34  5    6 ...
└─┴───┴┴──┴────┴─
```

可以發現呼叫的時間間隔並不相同，所以通常會將目標值乘上 `delta time` 來讓時間內結果能夠被預期

在 ALM 中開發任務也會遇到類似的情形，通常會使用 js 的 `setInterval()` 來達成

這裡必須說明，PuerTs 提供的 js 執行環境 tick 時機點其實是 C# 端來決定的，為了避免各種操作變得難以預測，ALM 的任務運行選擇將 tick 間隔固定 —— 使用 `Fixed Tick`[^2]，我們來觀察時間軸：

```text
Fixed Tick  1   2   3   4   5...
            └───┴───┴───┴───┴
            1 2   34  5    6 ...
Render Tick └─┴───┴┴──┴────┴─
```

可以發現：

1. 相同時間內 `Render Tick` 與 `Fixed Tick` 的次數不相同
2. 在 `Fixed Tick` 內，目標值不一定立即被渲染出來

因為這些原因，如果只在 `Fixed Tick` 內對值進行操作，渲染出來肯定是會有問題的，這就是為何需要使用 `Command`

由於 `Fixed Tick` 的時間間隔是已知的[^3]，利用這個特性，ALM 內使用 `Command` 操作就能做到不關心 `delta Time` 來完成值變化的操作，`Render Tick` 也能將當前的確切數值模擬出來[^4]

因此，我們只需要知道 `Fixed Tick` 每秒執行的次數 (Unity 預設 `Fixed Timestep` 為 `0.02` 秒，`1 / 0.02 = 50次/秒`)；假設希望某個物體以 `10單位/秒` 速度移動，只需要持續寫入 `0.2單位` 的位移就能達成

[^1]: 通常在 Unity 內為 `Update()` 方法
[^2]: 通常在 Unity 內為 `FixedUpdate()` 方法，但其實也能透過自定義的 tick loop 來與引擎脫鉤
[^3]: 它只是相對固定，不可能每次呼叫的間隔都完全相同，這裡忽略微小誤差
[^4]: 模擬指的是糙作判定應該都要基於 `Fixed Tick`，雖然目前沒有完全實作，有很多都還是在 `Render Tick` 內完成

## 關於 `Rng`

目前回放機能並不是紀錄所有物件的狀態，而是記錄操作，透過輸入 random seed 來保證回放時隨機結果相同。

由於 Javascript 的 `Math.random()` 並不提供 seed 輸入，所以要保證回放機能正常就需要使用到 `service.Rng` 來獲得隨機數 (於載入任務時就已經完成 seed 的設置，撰寫任務腳本時只需要呼叫對應類型的隨機函式即可)

## 關於 gltf 製作與使用

> 可參考 [headshot-flex 任務](../../../TsProject/src/missions/headshot-flex/)

任務可以匯入 gltf 類型的模型檔，因為是開放格式，相較 obj 可附帶更多內容，也解決 fbx 在 runtime 匯入有困難的問題。

### 場景模型

以下為保留名稱，在載入模型時會被主程式使用：

- `Origin` 為地圖原點
- `Player` 玩家原點
