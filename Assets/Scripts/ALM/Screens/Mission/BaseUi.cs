using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base;

    public class BaseUi : UIBase
    {
        public override uint Index => ((uint)UIIndex.Base);

        protected override string BaseElementName => "BaseUI";

        Label _timerLabel;

        protected override void AfterConfig()
        {
            _timerLabel = _elementBase.Q<Label>("TimerLabel");
        }

        public override void Overlapped() { }

        public override void Pop() { }

        public override void Push()
        {
            var timer = UIStackHandler.Current()?.data as Timer;
            timer.OnUpdateInt += UpdateTimer;
        }

        public override void Return() { }

        void UpdateTimer(int t)
        {
            _timerLabel.text =
                (t / 60).ToString("D2") + ':' +
                (t % 60).ToString("D2");
        }
    }
}

