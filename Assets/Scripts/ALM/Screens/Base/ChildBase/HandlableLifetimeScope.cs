using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using ALM.Common;
    using ALM.Screens.Menu;

    using ConstTickGroup = Common.TickableGroup<TickTiming.ConstRender>;
    using ConstFixedTickGroup = Common.TickableGroup<TickTiming.ConstFixed>;
    using TickGroup = Common.TickableGroup<TickTiming.ManagedRender>;
    using FixedGroup = Common.TickableGroup<TickTiming.ManagedFixed>;

    public abstract class HandlableLifetimeScope<TScope, TEntry> : LifetimeScope
        where TScope : HandlableLifetimeScope<TScope, TEntry>
        where TEntry : HandlableEntry<TEntry>
    {
        protected virtual Type[] UiTypes() => Array.Empty<Type>();

        public abstract record LoadPayload();

        public async static UniTask Load(LoadPayload payload = null)
        {
            var attr = Attribute.GetCustomAttribute(typeof(TScope), typeof(HandlabeSceneAttribute));

            if (attr is not HandlabeSceneAttribute sceneAttr)
                throw new InvalidOperationException("HandlabeSceneAttribute is not found.");

            await SceneManager.LoadSceneAsync(sceneAttr.SceneName).ToUniTask();

            var scope = LifetimeScope.Find<TScope>() as TScope;
            await scope.AfterLoad(payload);

            if (!scope.autoRun)
                scope.Build();
        }

        /// <summary>
        /// Scene loaded, before scope build.
        /// </summary>
        public virtual UniTask AfterLoad(LoadPayload payload) =>
            UniTask.CompletedTask;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TEntry>()
                .AsSelf()
                .As<HandlableEntry<TEntry>>();

            foreach (var ui in UiTypes())
                builder.Register(ui, Lifetime.Scoped).As<UIBase>();

            foreach (var x in
                FindObjectsByType<Component>(FindObjectsSortMode.None)
                    .Where(x => x is IManagedTickable))
                builder.RegisterComponent(x).AsImplementedInterfaces();

            builder.RegisterEntryPointExceptionHandler(ExcpetionHandler);

            builder.Register<ConstTickGroup>(Lifetime.Scoped);
            builder.Register<ConstFixedTickGroup>(Lifetime.Scoped);
            builder.Register<TickGroup>(Lifetime.Scoped);
            builder.Register<FixedGroup>(Lifetime.Scoped);
        }

        void ExcpetionHandler(Exception e)
        {
            Debug.LogError(e);
            MenuLifetimeScope.Load().Forget();
        }
    }
}
