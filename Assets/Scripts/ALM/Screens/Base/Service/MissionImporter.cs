using System.IO;
using ALM.Util;
using UnityEngine.TextCore.Text;

namespace ALM.Screens.Base
{
    public class MissionImporter
    {
        readonly string DEFAULT_PATH =
            UnityEngine.Application.dataPath +
                "/../" +
                "/mission-import";

        public MissionImporter()
        {
            Directory.CreateDirectory(DEFAULT_PATH);
        }

        public void Import()
        {
            var folders = Directory.GetDirectories(DEFAULT_PATH);

            foreach (var folder in folders)
            {
                if (!MissionValidator.Validate(folder))
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
            }
        }
    }
}