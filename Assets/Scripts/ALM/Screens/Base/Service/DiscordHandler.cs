using System;
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

        public DiscordHandler()
        {
            discord = new(
                Constants.Discord.APP_ID,
                logger: new Logger());

            discord.Initialize();
        }

        public void SetMission(MissionOutline mission)
        {
            SetActivity(new()
            {
                State = mission.Name,
                Details = mission.Description,
            });
        }

        public void SetActivity(RichPresence presence)
        {
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