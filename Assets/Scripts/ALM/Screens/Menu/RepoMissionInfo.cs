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
        public record Payload(RepoContent Repo, MissionOutline Outline);

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        QuickHint _quickHint;

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

            UpdateInfo(payload.Outline);
        }

        private void Download(ClickEvent _)
        {
            if (UIStackHandler.Current().data is not Payload payload)
                throw new Exception("MissionOutline is null");

            _missionImporter.DownloadMission(payload.Repo, payload.Outline)
                .ContinueWith(m => _quickHint.Show("Imported: " + payload.Outline.Name, 1.5f))
                .Forget();
        }
    }
}
