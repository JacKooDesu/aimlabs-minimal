using System;
using VContainer;
using Puerts;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using Data;

    public record JsConfigure(
        RaycasterService Raycaster,
        BallPoolService BallPool,
        AudioService Audio,
        ScoreService Score,
        MissionScoreData ScoreData);

    // this is delegate to configure service required by js env
    public delegate void JsConfigureDel(JsConfigure configure);

    public static class JsInjector
    {
        public static void Config(this JsConfigure instance, JSObject jsObj)
        {
            var configDel = jsObj.Get<JsConfigureDel>("configure");
            configDel?.Invoke(instance);
        }
    }
}