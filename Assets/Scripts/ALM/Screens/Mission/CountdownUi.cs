using System;
using UnityEngine.UIElements;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base;

    public class CountdownUi : UIBase
    {
        public override uint Index => ((uint)UIIndex.Countdown);
        protected override string BaseElementName => "CountDownText";

        Label _countdownText;

        protected override void AfterConfig()
        {
            _countdownText = _elementBase.Q<Label>();
        }

        public override void Overlapped() { }

        public override void Pop()
        {
            _elementBase.AddToClassList("inactive");
        }

        public override void Push()
        {
            _elementBase.RemoveFromClassList("inactive");

            var timer = UIStackHandler.Current().data as Timer;
            timer.OnUpdateInt += UpdateText;
            timer.OnComplete += 
                () => timer.OnUpdateInt -= UpdateText;
        }

        void UpdateText(int t)
        {
            (_elementBase as Label).text = t.ToString();
        }

        public override void Return() { }
    }
}