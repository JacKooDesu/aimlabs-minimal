using System;
using System.Collections.Generic;
using System.Linq;
using ALM.Common;
using ALM.Data;
using ALM.Util.Debugger;
using DiscordRPC;
using DiscordRPC.Logging;

namespace ALM.Screens.Base
{
    public class DiscordHandler : IManagedTickable, IDisposable
    {
        DiscordRpcClient discord;
        Button _downloadButton = new()
        {
            Label = "Download ALM",
            Url = Constants.Url.GITHUB_REPO
        };

        public DiscordHandler()
        {
            discord = new(
                Constants.Discord.APP_ID,
                logger: new Logger());

            // discord.RegisterUriScheme();
            discord.Initialize();
        }

        public void SetMission(
            MissionOutline mission,
            string downloadUrl = null)
        {
            SetActivity(new()
            {
                State = mission.Name,
                Details = mission.Description,
                Buttons = _Buttons()
            });

            DiscordRPC.Button[] _Buttons() => downloadUrl is null ?
                Array.Empty<DiscordRPC.Button>() :
                new DiscordRPC.Button[] { new(){
                    Label = "Get Mission",
                    Url = downloadUrl
                } };
        }

        public void SetActivity(RichPresence presence)
        {
            List<Button> btns = presence.Buttons?.ToList() ?? new();
            btns.Add(_downloadButton);
            presence.Buttons = btns.ToArray();
            discord.SetPresence(presence);
        }

        public void Tick()
        {
            // discord.Invoke();
        }

        public void Dispose()
        {
            discord.Dispose();
        }

        class Logger : DiscordRPC.Logging.ILogger
        {
            public LogLevel Level { get; set; } = DebuggerEntry.IsDebugMode ?
                LogLevel.Trace : LogLevel.Warning;

            public void Error(string message, params object[] args)
            {
                UnityEngine.Debug.LogErrorFormat(message, args);
            }

            public void Info(string message, params object[] args)
            {
                UnityEngine.Debug.LogFormat(message, args);
            }

            public void Trace(string message, params object[] args)
            {
                UnityEngine.Debug.LogFormat(message, args);
            }

            public void Warning(string message, params object[] args)
            {
                UnityEngine.Debug.LogWarningFormat(message, args);
            }
        }
    }
}