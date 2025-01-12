using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Realms;

namespace ALM.Screens.Base
{
    using System.Diagnostics;
    using ALM.Data;
    using ALM.Util;
    using VContainer;

    public class MissionLoader : IDisposable
    {
        readonly Realm _realm;
        readonly IDisposable realmChangeToken;

        public int MissionVersion { get; private set; } = Int32.MinValue;
        List<PlayableMission> _missions { get; } = new();

        public record PlayableMission(
            MissionOutline Outline,
            string Path,
            string[] Scripts);

        public MissionLoader(Realm realm)
        {
            _realm = realm;

            var missionDatas = _realm.All<MissionData>();
            realmChangeToken = missionDatas.AsRealmCollection()
                .SubscribeForNotifications(MissionDataCallback);

            _missions.AddRange(missionDatas.Select(ToPlayableMission));

            if (_missions.Count is 0)
                ReScanMissions();
            else
                MissionVersion++;
        }

        void MissionDataCallback(IRealmCollection<MissionData> sender, ChangeSet changes)
        {
            if (changes is null)
                return;

            if (changes.IsCleared)
            {
                _missions.Clear();
                MissionVersion++;
                return;
            }

            foreach (var c in changes.DeletedIndices)
                _missions.RemoveAt(c);

            foreach (var c in changes.InsertedIndices)
                _missions.Add(ToPlayableMission(sender[c]));

            foreach (var c in changes.NewModifiedIndices)
                _missions[c] = ToPlayableMission(sender[c]);

            MissionVersion++;
        }

        PlayableMission ToPlayableMission(MissionData data)
        {
            if (!MissionValidator.Validate(
                    FileIO.GetPath(Constants.MISSION_PATH, data.Name),
                    out var outline,
                    out var scripts,
                    out var fullPath))
            {
                UnityEngine.Debug.LogError("Missing mission folder in database: " + data.Name);
                return null;
            }

            ("Mission loaded: " + data.Name).Dbg();

            data.Outline = outline;

            return new(
                outline,
                fullPath,
                scripts);
        }

        public void ReScanMissions()
        {
            var missionDir = FileIO.GetPath(Constants.MISSION_PATH);

            using (var transaction = _realm.BeginWrite())
            {
                foreach (var mission in Directory.GetDirectories(missionDir))
                {
                    if (!MissionValidator.Validate(
                                mission,
                                out var outline,
                                out _,
                                out _))
                        continue;

                    try
                    {
                        _realm.Add(new MissionData()
                        {
                            Name = outline.Name
                        });
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError(e);
                        transaction.Rollback();
                    }

                    ("Mission added: " + mission).Dbg();
                }

                if (transaction.State == TransactionState.Running)
                    transaction.Commit();
            }
        }

        public PlayableMission GetMission(int index) =>
            _missions[index];
        public PlayableMission GetMission(string name) =>
            _missions.Find(x => x?.Outline.Name == name);
        public IEnumerable<PlayableMission> GetMissions() =>
            _missions.Where(x => x is not null);

        public void Dispose()
        {
            realmChangeToken.Dispose();
        }
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