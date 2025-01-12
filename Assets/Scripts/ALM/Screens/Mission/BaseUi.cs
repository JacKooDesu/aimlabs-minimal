using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Mission
{
    using System;
    using System.ComponentModel;
    using ALM.Common;
    using ALM.Screens.Base;
    using Data;

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

            _scoreData.PropertyChanged += OnScoreChange;
        }

        private void OnScoreChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is nameof(_scoreData.Score))
                _scoreLabel.text = _scoreData.Score.ToString();

            if (e.PropertyName is nameof(_scoreData.Accuracy))
                _accLabel.text = _scoreData.Accuracy.ToString("P0");
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

