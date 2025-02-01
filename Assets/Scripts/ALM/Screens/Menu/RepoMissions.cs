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
        [Inject]
        LoadingPanel _loadingPanel;
        VisualElement _functionPanel;
        ScrollView _selectionInner;

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _functionPanel = _elementBase.Q(name: "RepoFunctions");
            _selectionInner = _elementBase.Q<ScrollView>(name: "SelectionInner");

            _functionPanel.Q<Button>("RefreshBtn")
                .RegisterCallback<ClickEvent>(_ => RefreshRepoContents(forceUpdate: true));
        }

        public override void Push()
        {
            base.Push();
            _selectionInner.contentContainer.Clear();

            if (UIStackHandler.Current().data is not Data.MissionRepo repo)
                return;

            RefreshRepoContents(repo);
        }

        void OnSelectMission(RepoContent repo, Data.MissionOutline mission)
        {
            UIStackHandler.PushUI(
                (uint)UIIndex.RepoMissionInfo,
                new RepoMissionInfo.Payload(repo, mission));
        }

        void RefreshRepoContents(
            Data.MissionRepo repo = null, bool forceUpdate = false)
        {
            if ((repo ??= (UIStackHandler.Current().data as Data.MissionRepo)) is null)
                return;

            _loadingPanel.ShowSync(
                _missionImporter.GetRepoContent(repo, forceUpdate)
                .ContinueWith(c => UpdateButton(c)));

            void UpdateButton(RepoContent c)
            {
                _functionPanel.Q<Label>("RepoName").text = repo.Name;

                _selectionInner.contentContainer.Clear();
                foreach (var mission in c.Missions)
                {
                    var button = new Button();
                    button.text = mission.Name;
                    button.RegisterCallback<ClickEvent>(_ => OnSelectMission(c, mission));
                    _selectionInner.contentContainer.Add(button);
                }
            }
        }
    }
}