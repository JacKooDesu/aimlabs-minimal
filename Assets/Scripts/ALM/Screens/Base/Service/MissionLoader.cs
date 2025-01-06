using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace ALM.Screens.Base
{
    using ALM.Data;
    using ALM.Util;

    public class MissionLoader
    {
        public int MissionVersion { get; private set; } = Int32.MinValue;
        List<PlayableMission> _missions { get; } = new();

        public record PlayableMission(
            MissionOutline Outline,
            string Path,
            string[] Scripts);

        public MissionLoader()
        {
            Reload();
        }

        public void Reload()
        {
            _missions.Clear();

            var missionDir = FileIO.GetPath(Constants.MISSION_PATH);
            if (!Directory.Exists(missionDir))
                Directory.CreateDirectory(missionDir);

            foreach (var mFolder in Directory.GetDirectories(missionDir))
            {
                if (!MissionValidator.Validate(
                        mFolder,
                        out var outline,
                        out var scripts,
                        out var fullPath))
                    continue;

                _missions.Add(new(
                    outline,
                    fullPath,
                    scripts));
                $"Mission loaded: {outline.Name}".Dbg();
            }

            MissionVersion++;
        }

        public PlayableMission GetMission(int index) =>
            _missions[index];
        public PlayableMission GetMission(string name) =>
            _missions.Find(x => x.Outline.Name == name);
        public IEnumerable<PlayableMission> GetMissions() =>
            _missions;
    }

    public static class MissionValidator
    {
        public static bool Validate(string mFolder) =>
            Validate(mFolder, out _, out _, out _);

        public static bool Validate(
            string mFolder,
            out MissionOutline outline,
            out string[] scripts,
            out string fullPath)
        {
            outline = null;
            scripts = Array.Empty<string>();
            fullPath = string.Empty;

            DirectoryInfo di = new(mFolder);

            var outlinePath = Path.Combine(
                di.FullName,
                $"{(di.Name)}.json");

            if (!File.Exists(outlinePath))
            {
                $"Mission outline missing:\n{outlinePath}".Dbg();
                return false;
            }

            scripts = di
                .GetFiles("*.*js")
                .Select(x => x.FullName)
                .ToArray();

            if (scripts.Length is 0)
            {
                $"Mission with no scripts:\n{mFolder}".Dbg();
                return false;
            }

            outline = FileIO.JLoad<MissionOutline>(outlinePath);
            fullPath = di.FullName;
            return true;
        }

        /// <summary>
        /// Validate mission zip file, the json always at first element
        /// </summary>
        public static ZipArchiveEntry[] Validate(ZipArchive archive)
        {
            var scriptCount = 0;
            List<ZipArchiveEntry> entries = new();

            var outline = archive.Entries
                    .First(e => GetMissionPath(e));

            if (outline is null)
                return Array.Empty<ZipArchiveEntry>();

            entries.Add(outline);

            var path = string.Join('/', outline!
                .FullName
                .Split('/')[..^1]) + '/';
            var isRoot = path is "/";
            foreach (var e in archive.Entries)
            {
                if (!isRoot && !e.FullName.StartsWith(path))
                    continue;

                if (e.FullName == path)
                    continue;

                if (e.FullName.EndsWith('/'))
                    continue;

                if (e == outline)
                    continue;

                if (e.FullName.EndsWith("js"))
                    scriptCount++;

                entries.Add(e);
            }

            return scriptCount > 0 ?
                entries.ToArray() : Array.Empty<ZipArchiveEntry>();

            bool GetMissionPath(ZipArchiveEntry entry)
            {
                var arr = entry.FullName.Split('/');
                return arr[^1].EndsWith(Constants.OUTLINE_EXT);
            }
        }

        static List<FileInfo> ScriptRecursion(DirectoryInfo di, List<FileInfo> list = null)
        {
            list ??= new();

            list.AddRange(di.GetFiles("*.*js"));

            foreach (var dir in di.GetDirectories())
                ScriptRecursion(dir, list);

            return list;
        }
    }
}