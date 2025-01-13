using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Realms;
using TsEnvCore;

namespace ALM.Util
{
    public static class VersionChecker
    {
        public static readonly int CurrentVersionInt = VersionToInt(Application.version);
        public static int MinCapableVersionInt { get; private set; }

        const string VERSION_SUPPORT_FILE = "min-version-support";

        readonly static string UPDATER_PATH =
            Application.dataPath +
            "/../updater";

        static List<(int From, int To, string Script)> _updateScripts { get; } = new();
        static Dictionary<string, UpgradeType> _upgradeTypeDict { get; } = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void _Init()
        {
            Directory.CreateDirectory(UPDATER_PATH);
            ScanUpdateScripts();

            MinCapableVersionInt = VersionToInt(Resources
                .Load<TextAsset>(VERSION_SUPPORT_FILE)
                .ToString());

            if (Directory.Exists(FileIO.SAVE_PATH))
                return;

            var oldVersions = ScanOldVersions();
            if (oldVersions.Length <= 0)
                return;

            var maxOldVersion = oldVersions
                .OrderByDescending(v => VersionToInt(v))
                .FirstOrDefault();

            if (!CheckCanConvert(maxOldVersion))
            {
                Debug.LogWarning($"Max version `{maxOldVersion}` uncompatible.");
                return;
            }

            var oldVersionRoot = FileIO.GetPath("../" + maxOldVersion);
            var newSavePath = FileIO.SAVE_PATH;

            Directory.Move(oldVersionRoot, newSavePath);
        }

        public static string[] ScanOldVersions() =>
            Directory.GetDirectories(FileIO.GetPath("../"), "v*.*.*")
                .Select(p => Path.GetFileName(p))
                .ToArray();

        static void ScanUpdateScripts()
        {
            _updateScripts.Clear();
            _upgradeTypeDict.Clear();

            Regex updaterPattern = new(@"v?\d+-\d+-\d+[a-z]?~v?\d+-\d+-\d+[a-z]?");
            var updaters = Directory
                .GetFiles(UPDATER_PATH)
                .Select(p => Path.GetFileName(p))
                .Where(p => updaterPattern.IsMatch(p));

            foreach (var updater in updaters)
            {
                // a-b-c~x-y-z.cjs
                var arr = updater[..^4].Split('~');
                _updateScripts.Add((
                    VersionToInt(arr[0], '-'),
                    VersionToInt(arr[1], '-'),
                    updater));
            }

            _updateScripts.Sort((a, b) => a.From - b.From);

            if (_updateScripts.Count == 0)
                return;

            if (_updateScripts[0].From is not 0)
                _updateScripts.Insert(0, (0, _updateScripts[0].From, ""));

            for (int i = 0; i < _updateScripts.Count - 1; i++)
            {
                var (current, next) = (_updateScripts[i], _updateScripts[i + 1]);
                if (current.To != next.From)
                    _updateScripts.Insert(i + 1, (current.To, next.From, ""));
            }
        }

        public static bool CheckCanConvert(string version)
        {
            if (!_upgradeTypeDict.TryGetValue(version, out var result))
            {
                result = _GetUpgradeType(version);
                _upgradeTypeDict.Add(version, result);
            }

            return result is not CannotUpgrade;
        }

        static UpgradeType _GetUpgradeType(string version)
        {
            var oldVersionInt = VersionToInt(version);

            // TODO: should downgrade
            if (CurrentVersionInt <= oldVersionInt)
                return new CannotUpgrade();

            if (oldVersionInt < MinCapableVersionInt)
            {
                List<int> indexList = new();
                for (int i = 0; i < _updateScripts.Count; i++)
                {
                    var current = _updateScripts[i];
                    if (current.From > oldVersionInt ||
                        current.To <= oldVersionInt ||
                        current.To > MinCapableVersionInt)
                        continue;

                    if (string.IsNullOrEmpty(current.Script))
                        return new CannotUpgrade();

                    indexList.Add(i);
                }

                return new UpgradeScript(indexList.ToArray());
            }

            return new UpgradeDirectly();
        }

        public static int VersionToInt(string version, char splitChar = '.')
        {
            if (version.StartsWith('v'))
                version = version.Substring(1);

            var subNum = 0;
            if (Enumerable.Range('a', 'z').Contains(version[^1]))
            {
                subNum = version[^1] - 'a' + 1;
                version = version[0..^1];
            }

            return version.Split(splitChar)
                .Select((v, i) => int.Parse(v) * (int)math.pow(100, 3 - i))
                .Sum() + subNum;
        }

        public static string IntToVersion(int versionInt, char splitChar = '.')
        {
            var subNum = versionInt % 100;
            versionInt /= 100;

            var parts = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                parts.Add(versionInt % 100);
                versionInt /= 100;
            }
            parts.Reverse();

            var version = string.Join(splitChar, parts);
            if (subNum > 0)
                version += (char)('a' + subNum - 1);

            return version;
        }

        public static async UniTask<string> CheckAppVersion()
        {
            const string API = "https://api.github.com/repos/JacKooDesu/aimlabs-minimal/releases/latest";
            var request = await UnityWebRequest.Get(API)
                .SendWebRequest()
                .ToUniTask();

            if (request.result is not UnityWebRequest.Result.Success)
                throw new Exception("Failed to get latest version from GitHub.");

            var json = JObject.Parse(request.downloadHandler.text);
            if (!json.TryGetValue("name", out var token))
                throw new Exception("Invalid response.");

            var latestVersion = VersionToInt(token.ToString());

            if (CurrentVersionInt < latestVersion)
            {
                if (json.TryGetValue("assets", out var assets) &&
                    assets is JArray assetsJson &&
                    assetsJson.Count > 0)
                {
                    var asset = assetsJson[0];
                    var url = asset["browser_download_url"].ToString();
                    return url;
                }
            }

            return string.Empty;
        }

        public static void DbMigration(Migration migration, ulong oldVersion)
        {
            var old = (int)oldVersion;

            var loader = new LoaderCollection();
            loader.AddLoader(new Puerts.DefaultLoader());
            loader.AddLoader(new TsEnvCore.RootBasedLoader(UPDATER_PATH));
            Puerts.JsEnv jsEnv = new(loader);
            jsEnv.UsingAction<Action<Migration>>();
            for (int i = 0; i < _updateScripts.Count; i++)
            {
                var (from, to, script) = _updateScripts[i];
                if (from <= old && old < to)
                {
                    var module = jsEnv.ExecuteModule(_updateScripts[i].Script);
                    module.Get<Action<Migration>>("migration")?.Invoke(migration);
                }
            }

            jsEnv.Dispose();
        }

        public abstract record UpgradeType();
        public record UpgradeDirectly() : UpgradeType;
        public record UpgradeScript(int[] ScriptIndexes) : UpgradeType;
        public record CannotUpgrade() : UpgradeType;
    }
}