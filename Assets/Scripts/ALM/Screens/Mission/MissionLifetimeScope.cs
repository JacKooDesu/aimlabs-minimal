using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;
using Puerts;
using Cysharp.Threading.Tasks;
using TsEnvCore;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base;
    using ALM.Screens.Base.Setting;
    using Data;
    using Realms;

    [HandlabeScene("Mission")]
    public class MissionLifetimeScope : HandlableLifetimeScope<MissionLifetimeScope, MissionEntry>
    {
        [SerializeField]
        string _missionName = null;
        bool _replay = false;
        PlayHistory _playHistory;

        [SerializeField]
        UIDocument _rootUi;
        [SerializeField]
        UnityEngine.UI.RawImage _crosshair;
        [SerializeField]
        GameObject _pauseBlur;

        protected override Type[] UiTypes() => new[]
        {
            typeof(PauseUi),
            typeof(CountdownUi),
            typeof(BaseUi),
        };

        public record MissionPayload(string MissionName) : LoadPayload;
        public record ReplayPayload(PlayHistory PlayHistory) : LoadPayload;
        public override void AfterLoad(LoadPayload payload)
        {
            if (payload is ReplayPayload rp)
            {
                _replay = true;
                _missionName = rp.PlayHistory.Mission.Name;
                _playHistory = rp.PlayHistory;

                return;
            }

            if (payload is MissionPayload mp)
            {
                _missionName = mp.MissionName;

                return;
            }

            throw new ArgumentException();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<JsConfigure>(Lifetime.Scoped);

            var missionLoader = Parent.Container.Resolve<MissionLoader>();
            var mission = missionLoader.GetMission(_missionName);

            builder.Register(_ => mission, Lifetime.Scoped);
            builder.Register<JsEnv>(
                r =>
                {
                    var loader = new LoaderCollection();
                    loader.AddLoader(new DefaultLoader());
                    loader.AddLoader(new TsEnvCore.RootBasedLoader(mission.Path));

                    return new JsEnv(loader);
                }, Lifetime.Scoped);

            builder.Register<BallPoolService>(Lifetime.Scoped);
            builder.Register<RaycasterService>(Lifetime.Scoped);
            builder.Register<PauseHandleService>(Lifetime.Scoped);
            builder.RegisterFactory<float, Timer>(
                _ => f => new(f),
                Lifetime.Scoped);
            builder.Register<ScoreService>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.Register<CrosshairService>(Lifetime.Scoped);

            builder.RegisterComponent<UIDocument>(_rootUi);
            builder.RegisterComponent(_crosshair);

            builder.Register(
                r => r.Resolve<PlayHistory>().ScoreData,
                Lifetime.Scoped);

            // replay use fixedDeltaTime
            builder.RegisterInstance<Time>(new(_replay));

            if (_replay)
            {
                builder.Register(r =>
                {
                    var jsEnv = r.Resolve<JsEnv>();
                    return IManagedFixedTickable.Create(jsEnv.Tick);
                }, Lifetime.Scoped);
                builder.Register(r =>
                {
                    var missionData = _playHistory.Mission;
                    return new PlayHistory(missionData, new());
                }, Lifetime.Scoped);
                builder.Register<Replay>(
                    r => Replay.Deserialize(_playHistory.ReplayData).Dbg(),
                    Lifetime.Scoped);
                builder.Register<ReplayController>(Lifetime.Scoped)
                    .AsImplementedInterfaces();

                builder.Register<Util.Rng>(
                    r => new Util.Rng(r.Resolve<Replay>().RandomSeed), Lifetime.Scoped);
            }
            else
            {
                builder.Register<Replay>(
                    r => new(r.Resolve<Util.Rng>().Seed), Lifetime.Scoped);

                builder.Register(r =>
                {
                    var missionData = r.Resolve<Realm>().Find<MissionData>(_missionName);
                    return new PlayHistory(missionData, new());
                }, Lifetime.Scoped);
                builder.Register(r =>
                {
                    var jsEnv = r.Resolve<JsEnv>();
                    return IManagedTickable.Create(jsEnv.Tick);
                }, Lifetime.Scoped);
                builder.Register<FpsController>(Lifetime.Scoped)
                    .AsImplementedInterfaces();

                if (mission.Outline.Time > 0)
                    builder.Register<RecordService>(Lifetime.Scoped)
                        .AsImplementedInterfaces();

                builder.RegisterInstance<Util.Rng>(
                    new Util.Rng((uint)Guid.NewGuid().GetHashCode()));
            }

            builder.RegisterBuildCallback(r =>
            {
                r.Resolve<GameStatusHandler>().Register<MissionEntry>(GameStatus.Paused, () => _pauseBlur.SetActive(true));
                r.Resolve<GameStatusHandler>().Register<MissionEntry>(GameStatus.Playing, () => _pauseBlur.SetActive(false));
            });
        }
    }
}
