using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Menu
{
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base;

    public class RepoMissions : MenuUIBase
    {
        public override uint Index => (uint)UIIndex.RepoMissions;

        protected override string BaseElementName => "RepoMissions";

        [Inject]
        MissionImporter _missionImporter;
        VisualElement _selectionInner;

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _selectionInner = _elementBase.Q(name: "SelectionInner");
        }

        public override void Push()
        {
            base.Push();

            if (UIStackHandler.Current().data is not Data.MissionRepo repo)
                return;

            _missionImporter.GetRepoContent(repo)
                .ContinueWith(c => UpdateButton(c))
                .Forget();

            void UpdateButton(RepoContent c)
            {
                _selectionInner.Clear();

                foreach (var mission in c.Missions)
                {
                    var button = new Button();
                    button.text = mission.Name;
                    button.RegisterCallback<ClickEvent>(_ => OnSelectMission(c, mission));
                    _selectionInner.Add(button);
                }
            }
        }

        void OnSelectMission(RepoContent repo, Data.MissionOutline mission)
        {
            UIStackHandler.PushUI(
                (uint)UIIndex.RepoMissionInfo,
                new RepoMissionInfo.Payload(repo, mission));
        }
    }
}