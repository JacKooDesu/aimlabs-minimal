[開發紀錄](https://www.youtube.com/playlist?list=PLG-7kiz0ACzoNg00PC8ezm3Dl2S-2Edmh)

# AimLabs 極簡版

我是欠缺練習的 FPS 遊戲愛好者，之前用 AimLabs 來提升技術。但它現在又大又圓，廣告多而且大小來到了 10 多 GB。

所以這就是為什麼有了 AimLabs 極簡版，簡稱 ALM！！

## 目標

- 保持主執行檔案小容量
- 非營利且希望社群能夠協助使其成為更好的訓練工具
- 透過 PuerTs，任務可使用 js 腳本擴展。其中一個開發方向是提供綁定以使任務開發更容易
- 高度客製化
- 計劃部署標準化任務儲存庫，每個人都可以託管服務
- ~~計劃開發 Webgl 版本，意味著你不需要下載到硬碟中~~（由於 PuerTs 未提供適當的方式在 webgl 上熱重載腳本，開發已暫停）

## 下載

可以在 Release 內下載

### Windows

[連結](https://github.com/JacKooDesu/aimlabs-minimal/releases/latest)

### Linux

### ~~WebGL~~

~~[連結]()~~

## 問答

### 關於 [更新器](../updater/)

當數據庫版本過舊時（[min-version-support](../Assets/Resources/min-version-support.txt)），會需要這些遷移更新腳本來更新它
只需下載並將它們放入 `[game-root]/updater`

### 如何匯入任務

遊戲執行檔案資料夾中有一個預設的 `missions` 資料夾，可以將任務資料夾/壓縮檔放入其中，然後點擊 `Import Mission` > `Auto Import`
您也可以使用 `Select File` 並選擇磁碟中的任務壓縮檔來匯入
> 注意：目前，遊戲建置壓縮檔中預設包含一些任務，這些任務由我維護，通常用來展示 ALM 的一些關鍵功能

### 關於準心設定

準心設定是使用 [crosshair-config.js](../Assets/Resources/crosshair-config.cjs) 來完成的，詳細請看 [如何新增自訂準心腳本](./template/crosshair-config/README.md)

### 關於任務儲藏庫

雖然還沒詳細規範與開發，但簡短來說，希望訓練任務能夠流通化，並提供玩家一個簡單的方式獲取

## 開發

> 我 TypeScript 和 JavaScript 都很菜。如果發現有什麼錯誤或寫得不好的地方，請幫助我

### 主要專案

- Unity
  - 6000.0.31f1
  - URP
- 插件
  - [PuerTs](https://puerts.github.io)
  - [VContainer](https://vcontainer.hadashikick.jp)
  - [UniTask](https://github.com/Cysharp/UniTask)
  - [Realms](https://github.com/realm/realm-dotnet)
  - [Discord RPC](https://github.com/lachee/discord-rpc-csharp)
  - [glTFast](https://github.com/atteneder/glTFast)

### 任務開發

- 可用的 API 已在 [index.d.ts](../Assets/Gen/Typing/csharp/index.d.ts) 中生成
- [任務模板](../docs/template/mission/)
- 可透過添加 `-debugger` 參數開啟除錯模式

## TODO

## 後話

<details>

<summary>碎念</summary>

我不知道 aimlabs 哪一步走錯了，但沒有營收其實也很難用愛發電，維護好一個項目，希望這個項目能對標它並保持極簡化。另外除了對 aimlabs 的失望，其實更多是想用這個專案練練手並嘗試 puerts 以及最新的 unity 6。

</details>
