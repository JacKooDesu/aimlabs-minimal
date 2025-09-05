using System;
using ALM.Common;
using ALM.Data;
using ALM.Screens.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Menu
{
    public class RepoMissionInfo : MissionInfo
    {
        public override uint Index => (uint)UIIndex.RepoMissionInfo;
        protected override string BaseElementName => "RepoMissionInfo";
        public record Payload(string Endpoint, string MissionName);

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        QuickHint _quickHint;
        [Inject]
        LoadingPanel _loadingPanel;

        protected override void AfterConfig()
        {
            base.AfterConfig();
        }

        protected override void BindElement()
        {
            _elementBase.Q<Button>("Download").RegisterCallback<ClickEvent>(Download);
        }

        public override void Push()
        {
            SetHide(false);
            SetActive(true);

            if (UIStackHandler.Current().data is not Payload payload)
                throw new Exception("MissionOutline is null");

            _loadingPanel.ShowSync(
                _missionImporter.GetSourceMissionDetail(payload.Endpoint, payload.MissionName)
                .ContinueWith(c => UpdateInfo(c.Info)));
        }

        private void Download(ClickEvent _)
        {
            if (UIStackHandler.Current().data is not Payload payload)
                throw new Exception("MissionOutline is null");

            var task = _missionImporter.DownloadMission(payload.Endpoint, payload.MissionName)
                .ContinueWith(m => _quickHint.Show("Imported: " + payload.MissionName, 1.5f));


            _loadingPanel.ShowSync(
                _missionImporter.DownloadMission(payload.Endpoint, payload.MissionName),
                () => _quickHint.ShowSync("Imported: " + payload.MissionName, 1.5f));
        }
    }
}
