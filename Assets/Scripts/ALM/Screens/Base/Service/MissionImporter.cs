using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Realms;
using Newtonsoft.Json;
using VContainer;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

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
        readonly string DEFAULT_REPO_SETTING = "mission_repo.json";

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

        public string ImportZip(string path, bool delete = false)
        {
            string result = null;

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

                bool root = baseDir is "/";
                foreach (var e in entries)
                {
                    var name = root ?
                        e.FullName :
                        e.FullName.Replace(baseDir, "");
                    var dest = Path.Combine(
                        missionDirAbs,
                        name);

                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                    e.ExtractToFile(dest, true);
                }

                WriteToRealm(missionName);


                result = missionName;
            }

            if (delete)
                File.Delete(path);

            return result;
        }

        public MissionRepoList GetMissionRepoList()
        {
            var path = Path.Combine(
                DEFAULT_PATH,
                DEFAULT_REPO_SETTING);

            return FileIO.JLoad<MissionRepoList>(FileIO._File.Absolute(path), true);
        }

        public async UniTask<RepoContent> GetRepoContent(MissionRepo repo, bool forceUpdate = false)
        {
            if (!forceUpdate)
            {
                var data = _realm.Find<MissionRepoData>(repo.Name);
                if (data is not null)
                    return data.RepoContent;
            }

            var request = await UnityWebRequest
                .Get(repo.Endpoint)
                .SendWebRequest()
                .ToUniTask();

            if (request.result is not UnityWebRequest.Result.Success)
                throw new Exception("Failed to get mission list.");

            var content = JsonConvert.DeserializeObject<RepoContent>(request.downloadHandler.text);

            _realm.Write(() =>
            {
                _realm.Add(new MissionRepoData(repo, request.downloadHandler.text), update: true);
            });

            return content;
        }

        public async UniTask<string> DownloadMission(RepoContent repo, MissionOutline outline)
        {
            var result = await UnityWebRequest
                .Get(repo.GetMissionDownloadUrl(outline))
                .SendWebRequest()
                .ToUniTask();

            if (!result.isDone)
                throw new Exception("Failed to download mission.");


            var path = Path.Combine(
                DEFAULT_PATH,
                outline.Name + ".zip");

            File.WriteAllBytes(path, Convert.FromBase64String(result.downloadHandler.text));

            return ImportZip(path, true);
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

        // This is csharp version of mission md5 generator
        // Also see 'TsProject/mission-packager.js'
        string MissionMd5Generator(string missionPath)
        {
            var md5 = MD5.Create();

            var list = Directory.GetFiles(missionPath, "*", new EnumerationOptions() { RecurseSubdirectories = true })
                .Where(x => !x.EndsWith(".map") && !x.EndsWith(".md5"))
                .OrderBy(x => Path.GetFileName(x))
                .ToList();

            for (int i = 0; i < list.Count; i++)
            {
                using (FileStream fs = File.OpenRead(list[i]))
                {
                    // FIXME: use const size buffer?
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);

                    if (i == list.Count - 1)
                        md5.TransformFinalBlock(bytes, 0, bytes.Length);
                    else
                        md5.TransformBlock(bytes, 0, bytes.Length, bytes, 0);
                }
            }

            return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
        }
    }
}