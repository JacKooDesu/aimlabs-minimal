using UnityEngine.UIElements;
using VContainer;
using System.IO.Compression;

namespace ALM.Screens.Menu
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using ALM.Screens.Base;
    using ALM.Util;
    using Cysharp.Threading.Tasks;

    public class ImportMission : MenuUIBase
    {
        public override uint Index => ((uint)UIIndex.ImportMission);
        protected override string BaseElementName => "ImportPanel";

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        MissionLoader _missionLoader;
        [Inject]
        QuickHint _quickHint;

        protected override void AfterConfig()
        {
            _elementBase.Q<Button>("AutoImport").RegisterCallback<ClickEvent>(
                AutoImport);

            _elementBase.Q<Button>("SelectFile").RegisterCallback<ClickEvent>(
                SelectFile);
        }

        void AutoImport(ClickEvent _)
        {
            var result = _missionImporter.AutoImport();
            if (result.Count() is 0)
                return;

            DisplayResult(result);
            _missionLoader.Reload();
        }

        void SelectFile(ClickEvent _)
        {
            SFB.StandaloneFileBrowser.OpenFilePanelAsync(
                "Select Mission Zip",
                "",
                "zip",
                true,
                FileSelected);
        }

        void FileSelected(string[] paths)
        {
            if (paths.Length is 0)
                return;

            var result = paths.Where(p => !string.IsNullOrEmpty(_missionImporter.ImportZip(p)));
            DisplayResult(result);

            _missionLoader.Reload();
        }

        void DisplayResult(IEnumerable<string> missions)
        {
            _quickHint.Queue(
                missions.Select(nm => "Imported: " + nm),
                1.5f).Forget();
        }
    }
}