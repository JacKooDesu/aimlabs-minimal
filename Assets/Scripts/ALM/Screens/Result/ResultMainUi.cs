using VContainer;

namespace ALM.Screens.Result
{
    using System.Diagnostics;
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Menu;
    using ALM.Screens.Mission;
    using Cysharp.Threading.Tasks;
    using Unity.Mathematics;
    using UnityEngine.UIElements;

    internal class ResultMainUi : UIBase
    {
        public override uint Index => (uint)UIIndex.ResultMain;

        protected override string BaseElementName => string.Empty;

        [Inject]
        readonly MissionScoreData _scoreData;
        [Inject]
        readonly MissionOutline _missionOutline;

        protected override void AfterConfig()
        {
            // mission name
            _elementBase.Q<Label>("MissionName").text =
                _missionOutline.Name;

            // score
            _elementBase.Q<Label>("Score").text =
                "<size=32>SCORE</size>\n" +
                _scoreData.Score.ToString();

            // accuracy
            SetStatusValue(
                "Accuracy",
                _scoreData.Accuracy.ToString("P0"),
                _scoreData.Accuracy);

            // reaction
            SetStatusValue(
                "Reaction",
                (_scoreData.ReactionTime * 1000).ToString("F0") + "\nms",
                _scoreData.ReactionTime / 1.5f);

            _elementBase.Q<Button>("Retry").RegisterCallback<ClickEvent>(_ =>
                MissionLifetimeScope.Load(
                    new MissionLifetimeScope.Payload(_missionOutline.Name)).Forget());

            _elementBase.Q<Button>("Exit").RegisterCallback<ClickEvent>(_ =>
                MenuLifetimeScope.Load().Forget());
        }

        public override void Overlapped() { }

        public override void Pop() { }

        public override void Push()
        {

        }

        public override void Return() { }

        void SetStatusValue(string name, string value, float normalizedValue)
        {
            var element = _elementBase.Q(name);
            element.Q<Label>("StatusValue").text = value;

            var colorOrigin = element.Q("StatusContent").style.backgroundColor.value;
            element.Q("StatusContent").style.backgroundColor = UnityEngine.Color.HSVToRGB(
                math.lerp(0f / 360f, 120f / 360f, normalizedValue),
                .75f, .5f);
        }
    }
}