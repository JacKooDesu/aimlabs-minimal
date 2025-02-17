# 自訂準心

使用習慣的準心在射擊遊戲內也是相當重要的部分，ALM 希望能提供玩家自由度更高的準心設置方式。

## 講在前面

- 目前 ALM 沒有動態準心
- 準心就是一張圖，覆蓋在畫面中心
- 準心設置腳本在 `Setting` > `Crosshair` > `*` 時載入，路徑必須為 `~/[ALM-root]/systems/crosshair-config.cjs`
- 在設定中 `Apply` 就是把最後渲染的 `Texture2D` 輸出成圖檔

## 準心設定腳本

> 可參考 [crosshair-config.cts](../../../TsProject/src/game_systems/corsshair-config.cts) (ts 輸出為 [crosshair-config.cjs](../../../Assets/Resources/crosshair-config.cjs))

### UI 綁定

輸出函式 `binding(): CS.ALM.Screens.Base.CrosshairPanel.OptionSetting` 來讓 ALM 生成左側 UI。

其中 `Bindables` 集合可以生成對應 UI 與資料的接口。

### 準心畫布

輸出函式 `create(): CS.UnityEngine.Texture2D`，讓 ALM 初始化畫布。

### 準心繪製

輸出函式 `render(texture: CS.UnityEngine.Texture2D): void`，當 `binding()` 提供的 `Bindable` 變化時回呼，參數 `texture` 為最後輸出的畫布。

[`ALM.Util.Texturing`](../../../Assets/Scripts/ALM/Util/Texturing) 命名空間下提供了許多 `Texture2D` 繪製相關的類別與方法，可以建立 `Drawer` 物件來進行繪製。
