using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using Puerts;
using Cysharp.Threading.Tasks;
using TsEnvCore;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    public class MissionLifetimeScope : LifetimeScope
    {
        [SerializeField]
        string _missionName = null;

        public static async UniTask LoadMission(string missionName)
        {
            await SceneManager.LoadSceneAsync("Mission").ToUniTask();

            var scope = LifetimeScope.Find<MissionLifetimeScope>() as MissionLifetimeScope;
            scope._missionName = missionName;
            scope.Build();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            var missionLoader = Parent.Container.Resolve<MissionLoader>();
            var mission = missionLoader.GetMission(_missionName);

            builder.Register(_ => mission, Lifetime.Scoped);
            builder.RegisterEntryPoint<MissionEntry>();
            builder.Register<JsEnv>(
                r =>
                {
                    var loader = new LoaderCollection();
                    loader.AddLoader(new DefaultLoader());
                    loader.AddLoader(new TsEnvCore.Loader(mission.Path));

                    return new JsEnv(loader);
                }, Lifetime.Scoped);

            builder.Register<BallPoolService>(Lifetime.Scoped);
            builder.Register<RaycasterService>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<FpsCamController>();
        }
    }
}
