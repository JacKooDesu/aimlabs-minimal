using System.Collections.Generic;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Menu
{
    using System.Linq;
    using ALM.Screens.Base;
    using ALM.Screens.Mission;
    using ALM.Util;
    using Common;
    using Cysharp.Threading.Tasks;

    public class HistoryPanel : MenuUIBase
    {
        protected override string BaseElementName => "HistoryPanel";
        public override uint Index => ((uint)UIIndex.HistoryPanel);

        [Inject]
        readonly PlayHistoryService _playHistoryService;

        List<Button> _missionButtons { get; } = new();


        protected override void AfterConfig()
        {
            base.AfterConfig();
        }

        public override void Push()
        {
            base.Push();

            var selectionInner = _elementBase.Q<ScrollView>(name: "SelectionInner")
                .contentContainer;
            _missionButtons.ForEach(b => selectionInner.Remove(b));
            _missionButtons.Clear();

            if (UIStackHandler.Current().data is not string missionName)
                return;

            var histories = _playHistoryService.GetPlayHistories(missionName)
                .OrderByDescending(h => h.ScoreData.Score);
            foreach (var h in histories)
            {
                Button button = new();
                button.text =
                    h.PlayedAt.ToString("yyyy MMM d") +
                    ' ' +
                    h.ScoreData.Score.ToString();
                button.RegisterCallback<ClickEvent>(_ => Replay(h));
                selectionInner.Add(button);

                _missionButtons.Add(button);
            }
        }

        void Replay(Data.PlayHistory h)
        {
            // TODO: Replay here
            MissionLifetimeScope.Load(new MissionLifetimeScope.ReplayPayload(h))
                .Forget();
        }
    }
}