using System.Linq;
using ALM.Common;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    public abstract class HandlableLifetimeScope<TEntry> : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TEntry>();

            foreach (var x in
                FindObjectsByType<Component>(FindObjectsSortMode.None)
                    .Where(x => x is IManagedTickable))
                builder.RegisterComponent(x).AsImplementedInterfaces();
        }
    }
}
