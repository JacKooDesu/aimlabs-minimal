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
    using Data;

    public class MissionEntry : HandlableEntry<MissionEntry>
    {
        readonly JsEnv _jsEnv;
        readonly JsConfigure _jsConfigure;
        readonly MissionLoader.PlayableMission _mission;
        readonly PauseHandleService _pauseHandleService;
        readonly MissionScoreData _score;
        readonly Timer _timer;
        readonly Room _room;

        public MissionEntry(
            JsEnv jsEnv,
            JsConfigure jsConfigure,
            MissionLoader.PlayableMission mission,
            PauseHandleService pauseHandleService,
            MissionScoreData score,
            Room room,
            Func<float, Timer> timerFactory,
            UIDocument rootUi) : base(rootUi)
        {
            _jsEnv = jsEnv;
            _jsConfigure = jsConfigure;

            _mission = mission;
            _pauseHandleService = pauseHandleService;
            _score = score;
            _room = room;

            if (_mission.Outline.Time > 0)
                _timer = timerFactory(_mission.Outline.Time);
        }

        public override void Start()
        {
            _room.SetSize(_mission.Outline.MapSize);

            foreach (var script in _mission.Scripts)
            {
                _jsEnv.UsingAction<JsConfigureDel>();
                _jsEnv.UsingAction<JsScoreCalculator.CastedAction>();
                var module = _jsEnv.ExecuteModule(script);
                _jsConfigure.Config(module);
                var entry = module.Get<Action>("entry");
                entry?.Invoke();
            }

            // lock cursor
            Cursor.lockState = CursorLockMode.Locked;

            _handler.Register<MissionEntry>(
                GameStatus.Paused, () => Cursor.lockState = CursorLockMode.None);
            _handler.Register<MissionEntry>(
                GameStatus.Playing, () => Cursor.lockState = CursorLockMode.Locked);

            UIStackHandler.PushUI(((uint)UIIndex.Base), _timer);
            if (_timer is not null)
            {
                _timer.OnComplete += () => Result.ResultLifetimeScope.Load(
                    new Result.ResultLifetimeScope.Payload(
                        _mission.Outline, _score)).Forget();
                _timer.Reset();
            }
            _pauseHandleService.CountDown();
        }

        protected override void ConstTick()
        {
            _pauseHandleService.CheckState();
        }

        protected override void Tick()
        {
            _jsEnv.Tick();
            _timer?.Tick();
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