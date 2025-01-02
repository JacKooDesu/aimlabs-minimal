using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using Puerts;
using Cysharp.Threading.Tasks;
using TsEnvCore;

namespace ALM.Screens.Mission
{
    using System;
    using ALM.Screens.Base;
    using UnityEngine.UIElements;

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
        };

        public record Payload(string MissionName) : LoadPayload;
        public override void AfterLoad(LoadPayload payload)
        {
            var p = payload as Payload;
            _missionName = p.MissionName;
        }

        public static async UniTask LoadMission(string missionName)
        {
            await SceneManager.LoadSceneAsync("Mission").ToUniTask();

            var scope = LifetimeScope.Find<MissionLifetimeScope>() as MissionLifetimeScope;
            scope._missionName = missionName;
            scope.Build();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

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

            builder.RegisterComponent<UIDocument>(_rootUi);
        }
    }
}
