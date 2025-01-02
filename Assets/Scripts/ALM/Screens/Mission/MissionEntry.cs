using System;
using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;
using Puerts;

using Cursor = UnityEngine.Cursor;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base;

    public record JsConfigure(
        RaycasterService Raycaster,
        BallPoolService BallPool);
    // this is delegate to configure service required by js env
    public delegate void JsConfigureDel(JsConfigure configure);

    public class MissionEntry : HandlableEntry<MissionEntry>
    {
        readonly JsEnv _jsEnv;
        readonly MissionLoader.PlayableMission _mission;
        readonly BallPoolService _ballPoolService;
        readonly RaycasterService _raycasterService;
        readonly PauseHandleService _pauseHandleService;
        readonly Room _room;

        public MissionEntry(
            JsEnv jsEnv,
            MissionLoader.PlayableMission mission,
            BallPoolService ballPoolService,
            RaycasterService raycasterService,
            PauseHandleService pauseHandleService,
            Room room,
            UIDocument rootUi) : base(rootUi)
        {
            _jsEnv = jsEnv;
            _mission = mission;
            _ballPoolService = ballPoolService;
            _raycasterService = raycasterService;
            _pauseHandleService = pauseHandleService;
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

            _pauseHandleService.CountDown();
        }

        protected override void ConstTick()
        {
            _pauseHandleService.CheckState();
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