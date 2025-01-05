using UnityEngine.UIElements;
using VContainer;
using System.IO.Compression;

namespace ALM.Screens.Menu
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using ALM.Screens.Base;
    using ALM.Util;

    public class ImportMission : MenuUIBase
    {
        public override uint Index => ((uint)UIIndex.ImportMission);
        protected override string BaseElementName => "ImportPanel";

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        MissionLoader _missionLoader;

        protected override void AfterConfig()
        {
            _elementBase.Q<Button>("AutoImport").RegisterCallback<ClickEvent>(
                AutoImport);

            _elementBase.Q<Button>("SelectFile").RegisterCallback<ClickEvent>(
                SelectFile);
        }

        void AutoImport(ClickEvent _)
        {
            _missionImporter.Import();
            _missionLoader.Reload();
        }

        void SelectFile(ClickEvent _)
        {
            SFB.StandaloneFileBrowser.OpenFilePanelAsync(
                "Select Mission Zip",
                "",
                "zip",
                false,
                FileSelected);
        }

        void FileSelected(string[] paths)
        {
            foreach (var item in paths)
            {
                using (var archive = ZipFile.OpenRead(item))
                {
                    var entries = MissionValidator.Validate(archive);
                    if (entries.Length is 0)
                        continue;

                    var outlineEntry = entries[0];
                    var baseDir = string.Join('/', outlineEntry
                        .FullName
                        .Split('/')[..^1]) + '/';
                    var missionDir = FileIO.GetPath(
                        Constants.MISSION_PATH,
                        outlineEntry.FullName
                            .Split('/')[^1]
                            .Replace(".json", ""));

                    foreach (var e in entries)
                    {
                        if (e.FullName.EndsWith('/'))
                            continue;

                        var dest = Path.Combine(
                            missionDir,
                            e.FullName.Replace(baseDir, ""));

                        Directory.CreateDirectory(Path.GetDirectoryName(dest));
                        e.ExtractToFile(dest, true);
                    }
                }
            }

            _missionLoader.Reload();
        }
    }
}