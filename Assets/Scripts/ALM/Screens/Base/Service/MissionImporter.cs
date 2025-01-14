using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Realms;
using VContainer;

namespace ALM.Screens.Base
{
    using ALM.Data;
    using ALM.Util;

    public class MissionImporter
    {
        [Inject]
        readonly Realm _realm;
        readonly string DEFAULT_PATH =
            UnityEngine.Application.dataPath +
                "/../" +
                "/missions";

        public MissionImporter()
        {
            Directory.CreateDirectory(DEFAULT_PATH);
        }

        public string[] AutoImport()
        {
            List<string> result = new();

            var folders = Directory.GetDirectories(DEFAULT_PATH);

            foreach (var folder in folders)
            {
                if (!MissionValidator.Validate(folder, out var outline, out _, out _))
                    continue;

                var missionDir = FileIO.GetPath(Constants.MISSION_PATH);
                var dest = Path.Combine(
                    missionDir,
                    Path.GetFileName(folder));

                // TODO: Validate origin one here!! (version?)
                if (Directory.Exists(dest))
                {
                    Directory.Delete(dest, true);
                    $"Old Mission Deleted: {dest}".Dbg();
                }

                FileIO.CopyDirectory(folder, dest);
                Directory.Delete(folder, true);

                result.Add(outline.Name);

                WriteToRealm(outline.Name);
            }

            foreach (var file in Directory.GetFiles(DEFAULT_PATH, "*.zip"))
            {
                var missionName = ImportZip(file);
                if (string.IsNullOrEmpty(missionName))
                    continue;

                File.Delete(file);

                result.Add(missionName);

                WriteToRealm(missionName);
            }

            return result.ToArray();
        }

        public string ImportZip(string path)
        {
            using (var archive = ZipFile.OpenRead(path))
            {
                var entries = MissionValidator.Validate(archive);
                if (entries.Length is 0)
                    return null;

                var outlineEntry = entries[0];
                var baseDir = string.Join('/', outlineEntry
                    .FullName
                    .Split('/')[..^1]) + '/';
                var missionName = outlineEntry.FullName
                        .Split('/')[^1]
                        .Replace(Constants.OUTLINE_EXT, "");
                var missionDirAbs = FileIO.GetPath(
                    Constants.MISSION_PATH,
                    missionName);

                foreach (var e in entries)
                {
                    var dest = Path.Combine(
                        missionDirAbs,
                        e.FullName.Replace(baseDir, ""));

                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                    e.ExtractToFile(dest, true);
                }

                WriteToRealm(missionName);

                return missionName;
            }
        }

        void WriteToRealm(string missionName)
        {
            _realm.Write(() =>
            {
                _realm.Add(new MissionData()
                {
                    Name = missionName,
                }, update: true);
            });
        }
    }
}