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
    using ALM.Screens.Base;
    using Data;
    using Realms;

    [HandlabeScene("Mission")]
    public class MissionLifetimeScope : HandlableLifetimeScope<MissionLifetimeScope, MissionEntry>
    {
        [SerializeField]
        string _missionName = null;
        [SerializeField]
        UIDocument _rootUi;

        protected override Type[] UiTypes() => new[]
        {
            typeof(PauseUi),
            typeof(CountdownUi),
            typeof(BaseUi),
        };

        public record Payload(string MissionName) : LoadPayload;
        public override void AfterLoad(LoadPayload payload)
        {
            var p = payload as Payload;
            _missionName = p.MissionName;
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

            builder.RegisterComponent<UIDocument>(_rootUi);

            builder.Register(r =>
            {
                var missionData = r.Resolve<Realm>().Find<MissionData>(_missionName);
                return new PlayHistory(missionData, new());
            }, Lifetime.Scoped);
            builder.Register(
                r => r.Resolve<PlayHistory>().ScoreData,
                Lifetime.Scoped);
        }
    }
}
