using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using Common;

    public class SelectMission : MenuUIBase
    {
        protected override string BaseElementName => "MissionPanel";
        public override uint Index => ((uint)UIIndex.SelectMission);

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _elementBase.Q<Button>("TestMissionButton").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.MissionInfo));
        }
    }
}
