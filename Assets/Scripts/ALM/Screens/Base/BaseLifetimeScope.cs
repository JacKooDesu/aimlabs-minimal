using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using ALM.Common;
    using ALM.Util;
    using ALM.Util.UIToolkitExtend;
    using Setting;
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BaseEntry>();
            builder.Register<GameStatusHandler>(Lifetime.Singleton);

            builder.Register<GameplaySetting>(
                _ => GameplaySetting.Load(),
                Lifetime.Singleton);

            builder.Register<ControlSetting>(
                _ => ControlSetting.Load(),
                Lifetime.Singleton);

            builder.Register<ObjectSetting>(
                _ => ObjectSetting.Load(),
                Lifetime.Singleton);

            builder.Register<MissionLoader>(
                _ => new(),
                Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<SettingPanel>();
            builder.RegisterComponentInHierarchy<Room>();
            builder.RegisterComponentInHierarchy<ColorPickerUI>();
        }
    }
}

