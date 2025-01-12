using System;
using ALM.Screens.Base;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Menu
{
    [HandlabeScene("Menu")]
    public class MenuLifetimeScope : HandlableLifetimeScope<MenuLifetimeScope, MenuEntry>
    {
        [SerializeField] UIDocument _rootUi;

        protected override Type[] UiTypes() => new[]
        {
            typeof(MainMenu),
            typeof(SelectMission),
            typeof(MissionInfo),
            typeof(ImportMission),
            typeof(ManageAssets),
            typeof(AssetsList),
            typeof(HistoryPanel),
        };

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterComponent<UIDocument>(_rootUi);
        }
    }
}
