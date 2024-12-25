using System;
using System.Threading;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Puerts;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    public class MissionEntry : IAsyncStartable, ITickable
    {
        readonly JsEnv _jsEnv;
        readonly MissionLoader.PlayableMission _mission;

        public MissionEntry(
            JsEnv jsEnv,
            MissionLoader.PlayableMission mission)
        {
            _jsEnv = jsEnv;
            _mission = mission;
        }

        public async UniTask StartAsync(CancellationToken ct)
        {
            await UniTask.CompletedTask;
            foreach (var script in _mission.Scripts)
                _jsEnv.ExecuteModule(script);
        }

        public void Tick()
        {
            _jsEnv.Tick();
        }
    }
}