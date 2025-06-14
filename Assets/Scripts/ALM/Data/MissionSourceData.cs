using Realms;
using MemoryPack;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace ALM.Data
{
    public class MissionSourceData : RealmObject
    {
        [PrimaryKey]
        public string Endpoint { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Compressed json with memory pack
        /// </summary>
        public byte[] _SourceContentBytes { get; set; }
        MissionSourceContentResponse _sourceContent;
        public MissionSourceContentResponse SourceContent =>
            _sourceContent ??= JsonConvert.DeserializeObject<MissionSourceContentResponse>(MemoryPackSerializer.Deserialize<string>(_SourceContentBytes));

        [Backlink(nameof(SourceMissionData.Source))]
        public IQueryable<SourceMissionData> Missions { get; }

        public MissionSourceData() { }

        public MissionSourceData(
            string endpoint, MissionSourceContentResponse content, string jsonResponse)
        {
            Name = content.Name;
            Endpoint = endpoint;
            _SourceContentBytes = MemoryPackSerializer.Serialize(jsonResponse);
        }
    }

    public class SourceMissionData : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }
        public MissionSourceData Source { get; set; }
        public byte[] _DetailBytes { get; set; }
        MissionDetailResponse _missionDetail;
        public MissionDetailResponse MissionDetail =>
            _missionDetail ??= JsonConvert.DeserializeObject<MissionDetailResponse>(MemoryPackSerializer.Deserialize<string>(_DetailBytes));

        public SourceMissionData() { }

        public SourceMissionData(
            string name, MissionSourceData source, string jsonResponse)
        {
            Name = name;
            Source = source;
            _DetailBytes = MemoryPackSerializer.Serialize(jsonResponse);
        }
    }

    public static class MissionSourceDataExtension
    {
        public static string GetMissionDownloadUrls(
            this IQueryable<MissionSourceData> repos,
            MissionOutline outline)
        {
            return string.Empty;
            // foreach (var repo in repos)
            // {
            //     foreach (var mission in repo.SourceContent.Missions)
            //     {
            //         if (mission.Name != outline.Name)
            //             continue;

            //         var url = repo.SourceContent.GetMissionDownloadUrl(outline);
            //         if (url is not null)
            //             yield return url;
            //     }
            // }
        }
    }
}