# Mission Template

## core/alm-mission.cts

讓編輯邏輯的時候可以使用 `ALM` 內的服務元件，輸出時不需要打包進去

## main.cts

- `configure()` 方法是讓 `ALM` 把內建的服務元件注入到 `core/alm-mission.cts`
- `entry()` 方法會在服務元件註冊後呼叫，如果需要跟 `ALM` 交互，可以考慮將邏輯撰寫在這裡

## [mission-name].json

>檔名務必依照任務資料夾名稱命名

用來讓 ALM 辨識任務內容
