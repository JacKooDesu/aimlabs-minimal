using System.IO;
using System.Collections.Generic;

namespace ALM.Screens.Base
{
    using System.Linq;
    using ALM.Data;
    using ALM.Util;

    public class MissionLoader
    {
        const string MissionDir = "Missions";
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

            var missionDir = FileIO.GetPath(MissionDir);

            foreach (var mFolder in Directory.GetDirectories(missionDir))
            {
                DirectoryInfo di = new(mFolder);

                var outlinePath = Path.Combine(
                    di.FullName,
                    $"{(di.Name)}.json");
                if (!File.Exists(outlinePath))
                {
                    $"Mission load outline failed:\n{outlinePath}".Dbg();
                    continue;
                }

                var scripts = di
                    .GetFiles("*.*js")
                    .Select(x => x.FullName)
                    .ToArray();
                if (scripts.Length is 0)
                {
                    $"Mission load failed with no scripts:\n{mFolder}".Dbg();
                    continue;
                }

                var outline = FileIO.JLoad<MissionOutline>(outlinePath);
                _missions.Add(new(
                    outline,
                    di.FullName,
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
}