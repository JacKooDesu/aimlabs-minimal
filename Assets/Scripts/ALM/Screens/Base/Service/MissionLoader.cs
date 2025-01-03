using System.IO;
using System.Collections.Generic;

namespace ALM.Screens.Base
{
    using System;
    using System.Linq;
    using ALM.Data;
    using ALM.Util;

    public class MissionLoader
    {
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