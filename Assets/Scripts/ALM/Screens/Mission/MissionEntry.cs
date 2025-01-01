using System;
using System.Linq;
using System.Threading;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Puerts;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using UnityEditor;
    using UnityEngine;

    public record JsConfigure(
        RaycasterService Raycaster,
        BallPoolService BallPool);
    // this is delegate to configure service required by js env
    public delegate void JsConfigureDel(JsConfigure configure);

    public class MissionEntry : HandlableEntry
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

        public override void Start()
        {
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

            _handler.Register<MissionEntry>(
                GameStatus.Paused, () => Cursor.lockState = CursorLockMode.None);
            _handler.Register<MissionEntry>(
                GameStatus.Playing, () => Cursor.lockState = CursorLockMode.Locked);
        }

        protected override void Tick()
        {
            _jsEnv.Tick();
        }

        void AssignToJsEnv()
        {
        }

        public override void Dispose()
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}