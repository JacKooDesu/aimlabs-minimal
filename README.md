>**這個專案還處於非常早期的開發階段，如果有任何建議歡迎在 Issue 內提出！也很歡迎 PR！**
>
>**This project is in very early dev status. Leave comment in issue page if you have any good idea! PR accepted as well!**

[中文這裡](./docs/README-ZH.md)
[Dev Logs](https://www.youtube.com/playlist?list=PLG-7kiz0ACzoNg00PC8ezm3Dl2S-2Edmh)

# AimLabs Minimal

I am a poor skill FPS game lover and improve skill with AimLabs before. As you can see, the tool became bloated these day. (idk why a training tool can up to 10 or 20 gb)

So here comes AimLabs Minimal aka ALM!!

## Goals

- Keep the main executable binary in small file size
- Non-profit and hope comunity stronger make it better training tool
- By PuerTs, missions are expandable using js scripts, and a big develop direction is to provide bindings to make mission development easier
- High customized options
- Standardized mission repository deploy planned, everyone can host the service
- ~~Webgl version is planned as well, means you don't need to download it to your disk~~(since PuerTs not provide a proper way to hot-reload scripts on webgl, the develop has paused)

## Download

Can download it from release page

### Windows

[Link](https://github.com/JacKooDesu/aimlabs-minimal/releases/latest)

### Linux

### ~~Webgl~~

~~[Link]()~~

## Q&A

### About [Updater](./updater/)

When the version of database on your device too old([min-version-support](./Assets/Resources/min-version-support.txt)), you'll need those migration updater script to update it.
Simplily download and put them into `[game-root]/updater`.

### How to import Missions

The game exe folder has a default create folder named `missions`, which can placed mission folder/zip into it and simplily click `Import Mission` > `Auto Import`
You can use `Select File` and select the mission zip in your disk to import as well
> Note: Currently, the game build zip contains some missions by default, they are under maintenance by me and usually exampling some key features of ALM

### About Crosshair Config

Crosshair configuration is working by [crosshair-config.js](./Assets/Resources/crosshair-config.cjs), see more detail in [How to added own crosshair configure](./docs/template/crosshair-config/README.md)

### What is Mission Repo

Mission Repo is under construct but in short, hoping the training mission can be shared easily and provide a simple way for user to get them

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
  - [Discord RPC](https://github.com/lachee/discord-rpc-csharp)
  - [glTFast](https://github.com/atteneder/glTFast)

### Mission Develop

- The api you can use are generated in [index.d.ts](./Assets/Gen/Typing/csharp/index.d.ts)
- [The mission template](./docs/template/mission/)
- Debugger mode can be opened with argument `-debugger` added

## TODO
