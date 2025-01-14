>**這個專案還處於非常早期的開發階段，如果有任何建議歡迎在 Issue 內提出！也很歡迎 PR！**
>
>**This project is in very early dev status. Leave comment in issue page if you have any good idea! PR accepted as well!**

[中文這裡](./docs/README-ZH.md)

# AimLabs Minimal

I am a poor skill FPS game lover and improve skill with AimLabs before. As you can see, the tool became bloated these day. (idk why a training tool can up to 10 or 20 gb)

So here comes AimLabs Minimal aka ALM!!

## Features

- Very small file size and non-profit in this training tool
- Missions are expandable using js scripts
- Webgl version is planned as well, means you don't need to download it to your disk

## Download

Can download it from release page

### Windows

### Linux

### Webgl

[Link]()

## Q&A

### About [Updater](./updater/)

When the version of database on your device too old([min-version-support](./Assets/Resources/min-version-support.txt)), you'll need those migration updater script to update it.
Simplily download and put them into `[game-root]/updater`.

## Develop

>I am very new to TypeScript and JavaScript. Plz help me if figured there's something wrong or bad writing

### Main Project

- Unity
  - 6000.0.31f1
  - URP
- Plugins
  - [PuerTs](https://puerts.github.io)
  - [VContainer](https://vcontainer.hadashikick.jp)
  - [UniTask](https://github.com/Cysharp/UniTask)
  - [Realms](https://github.com/realm/realm-dotnet)

### Mission Develop

- The api you can use are generated in [index.d.ts](./Assets/Gen/Typing/csharp/index.d.ts)
- [The mission template](./docs/template/mission/)
- Debugger mode can be opened with argument `-debugger` added

## TODO
