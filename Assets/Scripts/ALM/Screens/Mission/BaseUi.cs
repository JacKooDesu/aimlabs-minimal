using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base;

    public class BaseUi : UIBase
    {
        public override uint Index => ((uint)UIIndex.Base);

        protected override string BaseElementName => "BaseUI";

        [Inject]
        public MissionScoreData _scoreData;

        Label _timerLabel;
        Label _scoreLabel;
        Label _accLabel;

        protected override void AfterConfig()
        {
            _timerLabel = _elementBase.Q<Label>("TimerLabel");
            _scoreLabel = _elementBase.Q<Label>("ScoreText");
            _accLabel = _elementBase.Q<Label>("AccText");

            _scoreData.OnAccuracyChange += acc =>
                _accLabel.text = acc.ToString("P0");
            _scoreData.OnScoreChanged += score =>
                _scoreLabel.text = score.ToString();
        }

        public override void Overlapped() { }

        public override void Pop() { }

        public override void Push()
        {
            var timer = UIStackHandler.Current()?.data as Timer;
            if (timer is not null)
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

