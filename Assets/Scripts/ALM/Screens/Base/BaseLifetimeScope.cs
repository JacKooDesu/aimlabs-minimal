using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using ALM.Util;
    using ALM.Util.UIToolkitExtend;
    using Setting;
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BaseEntry>();

            builder.Register<GameplaySetting>(
                c => FileIO.JLoad<GameplaySetting>(
                    "settings", "gameplay_setting.json", true),
                Lifetime.Singleton);

            builder.Register<ControlSetting>(
                c => FileIO.JLoad<ControlSetting>(
                    "settings", "control_setting.json", true),
                Lifetime.Singleton);
        }
    }
}

