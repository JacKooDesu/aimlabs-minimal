using System;
using VContainer;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace ALM.Screens.Result
{
    using ALM.Data;
    using ALM.Screens.Base;
    using ALM.Screens.Mission;

    [HandlabeScene("Result")]
    public class ResultLifetimeScope : HandlableLifetimeScope<ResultLifetimeScope, ResultEntry>
    {
        [SerializeField]
        UIDocument _rootUi;

        protected override Type[] UiTypes() => new[]
        {
            typeof(ResultMainUi),
        };

        Payload _payload;

        public record Payload(
            MissionOutline Mission,
            PlayHistory PlayHistory) : LoadPayload;
        public override void AfterLoad(LoadPayload payload)
        {
            if (payload is not Payload p)
                return;

            _payload = p;
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register(_ => _payload.PlayHistory, Lifetime.Scoped);
            builder.Register(_ => _payload.PlayHistory.ScoreData, Lifetime.Scoped);
            builder.Register(_ => _payload.Mission, Lifetime.Scoped);
            builder.RegisterComponent<UIDocument>(_rootUi);
        }
    }
}
