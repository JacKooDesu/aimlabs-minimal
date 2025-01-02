using UnityEngine;

namespace ALM.Screens.Mission
{
    using System;
    using ALM.Screens.Base;
    using ALM.Screens.Menu;
    using Common;
    using Cysharp.Threading.Tasks;
    using UnityEngine.UIElements;
    using VContainer;

    public class PauseUi : UIBase
    {
        [Inject]
        SettingPanel _settingPanel;
        [Inject]
        GameStatusHandler _handler;

        public override uint Index => ((uint)UIIndex.Pause);

        protected override string BaseElementName => "PausePanel";

        protected override void AfterConfig()
        {
            _elementBase.Q<Button>("Resume")
                .RegisterCallback<ClickEvent>(Resume);
            _elementBase.Q<Button>("Setting")
                .RegisterCallback<ClickEvent>(Setting);
            _elementBase.Q<Button>("BackTitle")
                .RegisterCallback<ClickEvent>(BackTitle);
        }

        public override void Overlapped()
        {
            _elementBase.AddToClassList("hide");
        }

        public override void Pop()
        {
            _elementBase.AddToClassList("inactive");
        }

        public override void Push()
        {
            _elementBase.RemoveFromClassList("inactive");
        }

        public override void Return()
        {
            _elementBase.RemoveFromClassList("hide");
        }

        void Resume(ClickEvent _)
        {
            UIStackHandler.PopUI();
        }

        void Setting(ClickEvent _)
        {
            Overlapped();
            UIStackHandler.PushUiUnsafe(SettingPanel.INDEX);
            _settingPanel.ActiveAsync(onClose: Return).Forget();
        }

        void BackTitle(ClickEvent _)
        {
            MenuLifetimeScope.Load().Forget();
        }
    }
}