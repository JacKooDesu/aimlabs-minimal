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
    using System.Linq;
    using ALM.Common;
    using ALM.Screens.Base;
    using ALM.Screens.Base.Setting;
    using Data;
    using Realms;

    [HandlabeScene("Mission")]
    public class MissionLifetimeScope : HandlableLifetimeScope<MissionLifetimeScope, MissionEntry>
    {
        [SerializeField]
        MissionLoader.PlayableMission _mission;
        bool _replay = false;
        PlayHistory _playHistory;

        [SerializeField]
        UIDocument _rootUi;
        [SerializeField]
        UnityEngine.UI.RawImage _crosshair;
        [SerializeField]
        GameObject _pauseBlur;

        GltfLoaderService _gltfLoaderService;

        protected override Type[] UiTypes() => new[]
        {
            typeof(PauseUi),
            typeof(CountdownUi),
            typeof(BaseUi),
        };

        public record MissionPayload(string MissionName) : LoadPayload;
        public record ReplayPayload(PlayHistory PlayHistory) : LoadPayload;
        public override async UniTask AfterLoad(LoadPayload payload)
        {
            var missionName = string.Empty;
            if (payload is ReplayPayload rp)
            {
                _replay = true;
                missionName = rp.PlayHistory.Mission.Name;
                _playHistory = rp.PlayHistory;
            }

            if (payload is MissionPayload mp)
            {
                missionName = mp.MissionName;
            }

            if (string.IsNullOrEmpty(missionName))
                throw new ArgumentException();

            var missionLoader = Find<BaseLifetimeScope>().Container.Resolve<MissionLoader>();
            _mission = missionLoader.GetMission(missionName);

            if (!string.IsNullOrEmpty(_mission.Outline.Map))
                await GltfCreator().RegisterSingle("MAP", _mission.Outline.Map);

            if (_mission.Outline.GltfResources is not null)
                await GltfCreator().RegisterPool(_mission.Outline.GltfResources);

            GltfLoaderService GltfCreator() =>
                _gltfLoaderService ??= new(_mission.Path);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<JsConfigure>(Lifetime.Scoped);

            builder.Register(_ => _mission, Lifetime.Scoped);
            builder.Register<JsEnv>(
                r =>
                {
                    var loader = new LoaderCollection();
                    loader.AddLoader(new DefaultLoader());
                    loader.AddLoader(new TsEnvCore.RootBasedLoader(_mission.Path));

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
            builder.Register<GltfLoaderService>(
                _ => _gltfLoaderService ?? new(),
                Lifetime.Scoped);

            builder.RegisterComponent<UIDocument>(_rootUi);
            builder.RegisterComponent(_crosshair);

            builder.Register(
                r => r.Resolve<PlayHistory>().ScoreData,
                Lifetime.Scoped);

            // replay use fixedDeltaTime
            builder.RegisterInstance<Time>(new(_replay));

            builder.Register<EntityService>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();

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
                    var missionData = r.Resolve<Realm>().Find<MissionData>(_mission.Outline.Name);
                    return new PlayHistory(missionData, new());
                }, Lifetime.Scoped);
                builder.Register(r =>
                {
                    var jsEnv = r.Resolve<JsEnv>();
                    return IManagedTickable.Create(jsEnv.Tick);
                }, Lifetime.Scoped);
                builder.Register<FpsController>(Lifetime.Scoped)
                    // If tracking mode use keep fire mode
                    .WithParameter<bool>(_mission.Outline.Type is Data.MissionOutline.MissionType.Tracking)
                    .AsImplementedInterfaces();

                if (_mission.Outline.Time > 0 &&
                    _mission.Outline.Type is not Data.MissionOutline.MissionType.Tracking)
                {
                    builder.Register<RecordService>(Lifetime.Scoped)
                        .AsImplementedInterfaces();
                }

                builder.RegisterInstance<Util.Rng>(
                    new Util.Rng((uint)Guid.NewGuid().GetHashCode()));
            }

            builder.RegisterBuildCallback(r =>
            {
                var pauseService = r.Resolve<PauseHandleService>();
                pauseService.OnPause += () => _pauseBlur.SetActive(true);
                pauseService.OnResume += () => _pauseBlur.SetActive(false);
            });
        }
    }
}
