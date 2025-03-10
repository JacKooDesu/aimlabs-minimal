using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using ALM.Screens.Base;
    using ALM.Screens.Mission;
    using Common;
    using Cysharp.Threading.Tasks;

    public class MissionInfo : MenuUIBase
    {
        protected override string BaseElementName => "MissionInfo";
        public override uint Index => ((uint)UIIndex.MissionInfo);

        Label _missionName;
        Label _missionDescription;
        Label _missionAuthor;

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _missionName = _elementBase.Q<Label>("MissionName");
            _missionDescription = _elementBase.Q<Label>("MissionDescription");
            _missionAuthor = _elementBase.Q<Label>("MissionAuthor");

            BindElement();
        }

        protected virtual void BindElement()
        {
            _elementBase.Q<Button>("Play").RegisterCallback<ClickEvent>(
                _ => MissionLifetimeScope.Load(new MissionLifetimeScope.MissionPayload(
                    (UIStackHandler.Current().data as MissionLoader.PlayableMission)
                        .Outline.Name)).Forget());

            _elementBase.Q<Button>("History").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.HistoryPanel,
                    (UIStackHandler.Current().data as MissionLoader.PlayableMission).Outline.Name));
        }

        public override void Push()
        {
            base.Push();

            var mission = UIStackHandler.Current().data as MissionLoader.PlayableMission;

            UpdateInfo(mission.Outline);
        }

        protected void UpdateInfo(Data.MissionOutline outline)
        {
            _missionName.text = outline.Name;
            _missionDescription.text = outline.Description;
            _missionAuthor.text = outline.Author;
        }
    }
}
