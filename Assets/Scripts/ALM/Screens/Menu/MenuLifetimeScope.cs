using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Menu
{
    public class MenuLifetimeScope : LifetimeScope
    {
        [SerializeField] UIDocument _rootUi;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MenuEntry>();
            builder.RegisterComponent<UIDocument>(_rootUi);

            builder.Register<MainMenu>(Lifetime.Scoped).As<MenuUIBase>();
            builder.Register<SelectMission>(Lifetime.Scoped).As<MenuUIBase>();
            builder.Register<MissionInfo>(Lifetime.Scoped).As<MenuUIBase>();
        }
    }
}
