using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;
using Puerts;

using Cursor = UnityEngine.Cursor;

namespace ALM.Screens.Mission
{
    using ALM.Util;
    using ALM.Common;
    using ALM.Screens.Base;
    using Data;
    using Realms;

    public class MissionEntry : HandlableEntry<MissionEntry>
    {
        readonly JsEnv _jsEnv;
        readonly JsConfigure _jsConfigure;
        readonly MissionLoader.PlayableMission _mission;
        readonly PauseHandleService _pauseHandleService;
        readonly PlayHistoryService _playHistoryService;
        readonly CrosshairService _crosshairService;
        readonly GltfLoaderService _gltfLoaderService;
        private readonly IPlayer _player;
        readonly PlayHistory _playHistory;
        readonly Timer _timer;
        readonly Room _room;
        readonly Replay _replay;

        public MissionEntry(
            JsEnv jsEnv,
            JsConfigure jsConfigure,
            MissionLoader.PlayableMission mission,
            PauseHandleService pauseHandleService,
            PlayHistoryService playHistoryService,
            PlayHistory playHistory,
            CrosshairService crosshairService,
            GltfLoaderService gltfLoaderService,
            IPlayer player,
            Room room,
            Replay replay,
            Realm realm,
            TickableGroup<TickTiming.ManagedRender> tickGroup,
            DiscordHandler discordHandler,
            Func<float, Timer> timerFactory,
            UIDocument rootUi) : base(rootUi)
        {
            _jsEnv = jsEnv;
            _jsConfigure = jsConfigure;

            _mission = mission;
            _pauseHandleService = pauseHandleService;
            _playHistoryService = playHistoryService;
            _crosshairService = crosshairService;
            _gltfLoaderService = gltfLoaderService;
            _player = player;

            _playHistory = playHistory;
            _room = room;
            _replay = replay.InputFrames.Count > 0 ? null : replay;

            if (_mission.Outline.Time > 0)
                tickGroup.Reg(
                    _timer = timerFactory(_mission.Outline.Time));

            discordHandler.SetMission(
                _mission.Outline,
                realm.All<MissionRepoData>()
                    .GetMissionDownloadUrls(_mission.Outline)
                    .FirstOrDefault());
        }

        public override void Start()
        {
            SetupRoom();

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
                _timer.OnComplete += OnFinishedMission;
                _timer.Reset();
            }
            _pauseHandleService.CountDown();
        }

        void SetupRoom()
        {
            if (_gltfLoaderService.TryGet("MAP", out var map))
            {
                if (map.transform.TryFind("Origin", out var origin))
                    map.transform.position = origin.worldToLocalMatrix
                        .MultiplyPoint3x4(map.transform.position);

                if (map.transform.TryFind("Player", out var player))
                    _player.SetPosition(player.position);

                _room.gameObject.SetActive(false);
            }
            else
            {
                _room.SetSize(_mission.Outline.MapSize);
            }
        }

        void OnFinishedMission()
        {
            if (_replay is not null &&
                _replay.InputFrames.Count is not 0)
                _playHistoryService.AddPlayHistory(
                    _playHistory, _replay.Serialize());

            Result.ResultLifetimeScope.Load(
                   new Result.ResultLifetimeScope.Payload(
                       _mission.Outline, _playHistory)).Forget();
        }

        protected override void ConstTick() { }

        protected override void Tick() { }

        protected override void FixedTick() { }


        public override void Dispose()
        {
            _room?.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}