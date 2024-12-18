using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BaseEntry>();

            builder.Register<ResolutionService>(Lifetime.Singleton);
        }
    }
}

