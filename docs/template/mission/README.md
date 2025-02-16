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

## 關於 gltf 製作與使用

> 可參考 [headshot-flex 任務](../../../TsProject/src/missions/headshot-flex/)

任務可以匯入 gltf 類型的模型檔，因為是開放格式，相較 obj 可附帶更多內容，也解決 fbx 在 runtime 匯入有困難的問題。

### 場景模型

以下為保留名稱，在載入模型時會被主程式使用：

- `Origin` 為地圖原點
- `Player` 玩家原點
