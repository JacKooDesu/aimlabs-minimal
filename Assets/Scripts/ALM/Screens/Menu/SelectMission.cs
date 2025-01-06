using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using System.Linq;
    using ALM.Screens.Base;
    using Common;

    public class SelectMission : MenuUIBase
    {
        protected override string BaseElementName => "MissionPanel";
        public override uint Index => ((uint)UIIndex.SelectMission);
        readonly MissionLoader _missionLoader;

        List<Button> _missionButtons { get; } = new();
        int _missionVersion;

        public SelectMission(MissionLoader missionLoader)
        {
            _missionLoader = missionLoader;
        }

        protected override void AfterConfig()
        {
            base.AfterConfig();
            GenerateMissionList();
        }

        public override void Push()
        {
            base.Push();

            if (_missionLoader.MissionVersion != _missionVersion)
                GenerateMissionList();
        }

        void GenerateMissionList()
        {
            var selectionInner = _elementBase.Q(name: "SelectionInner");

            _missionButtons.ForEach(button => selectionInner.Remove(button));
            _missionButtons.Clear();

            foreach (var mission in _missionLoader.GetMissions())
            {
                Button button = new();
                button.text = mission.Outline.Name;
                button.RegisterCallback<ClickEvent>(_ => OnSelectMission(mission));
                selectionInner.Add(button);

                _missionButtons.Add(button);
            }

            _missionVersion = _missionLoader.MissionVersion;
        }

        void OnSelectMission(MissionLoader.PlayableMission mission)
        {
            UIStackHandler.PushUI((uint)UIIndex.MissionInfo, mission);
        }
    }
}
