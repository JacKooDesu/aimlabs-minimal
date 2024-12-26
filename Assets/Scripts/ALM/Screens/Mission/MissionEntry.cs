using System;
using System.Linq;
using System.Threading;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Puerts;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using UnityEngine;

    public record JsConfigure(
        RaycasterService Raycaster,
        BallPoolService BallPool);
    // this is delegate to configure service required by js env
    public delegate void JsConfigureDel(JsConfigure configure);

    public class MissionEntry : IAsyncStartable, ITickable, IDisposable
    {
        readonly JsEnv _jsEnv;
        readonly MissionLoader.PlayableMission _mission;
        readonly BallPoolService _ballPoolService;
        readonly RaycasterService _raycasterService;
        readonly Room _room;

        public MissionEntry(
            JsEnv jsEnv,
            MissionLoader.PlayableMission mission,
            BallPoolService ballPoolService,
            RaycasterService raycasterService,
            Room room)
        {
            _jsEnv = jsEnv;
            _mission = mission;
            _ballPoolService = ballPoolService;
            _raycasterService = raycasterService;
            _room = room;
        }

        public async UniTask StartAsync(CancellationToken ct)
        {
            await UniTask.CompletedTask;

            _room.SetSize(_mission.Outline.MapSize);

            foreach (var script in _mission.Scripts)
            {
                _jsEnv.UsingAction<JsConfigureDel>();
                var module = _jsEnv.ExecuteModule(script);

                var configure = module.Get<Func<JsConfigureDel>>("configure");
                configure?.Invoke()?.Invoke(new(
                    _raycasterService,
                    _ballPoolService));

                var entry = module.Get<Action>("entry");
                entry?.Invoke();
            }

            // lock cursor
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Tick()
        {
            _jsEnv.Tick();
        }

        void AssignToJsEnv()
        {
        }

        public void Dispose()
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}