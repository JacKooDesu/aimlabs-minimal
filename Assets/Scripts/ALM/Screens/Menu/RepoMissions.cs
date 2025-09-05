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

            if (UIStackHandler.Current().data is not string endpoint)
                return;

            RefreshRepoContents(endpoint);
        }

        void OnSelectMission(string endpoint, string missionName)
        {
            UIStackHandler.PushUI(
                (uint)UIIndex.RepoMissionInfo,
                new RepoMissionInfo.Payload(endpoint, missionName));
        }

        void RefreshRepoContents(
            string endpoint = null, bool forceUpdate = false)
        {
            if ((endpoint ??= (UIStackHandler.Current().data as string)) is null)
                return;

            _loadingPanel.ShowSync(
                _missionImporter.GetSourceContent(endpoint, forceUpdate)
                .ContinueWith(c => UpdateButton(c)));

            void UpdateButton(MissionSourceContentResponse c)
            {
                _functionPanel.Q<Label>("RepoName").text = c.Name;

                _selectionInner.contentContainer.Clear();
                foreach (var mission in c.Missions)
                {
                    var button = new Button();
                    button.text = mission.Name;
                    button.RegisterCallback<ClickEvent>(_ => 
                        OnSelectMission(endpoint, mission.Name));
                    _selectionInner.contentContainer.Add(button);
                }
            }
        }
    }
}