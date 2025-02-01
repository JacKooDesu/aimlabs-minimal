using Realms;
using MemoryPack;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace ALM.Data
{
    public class MissionRepoData : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Endpoint { get; set; }

        /// <summary>
        /// Compressed json with memory pack
        /// </summary>
        public byte[] _RepoContentBytes { get; set; }
        RepoContent _repoContent;
        public RepoContent RepoContent =>
            _repoContent ??= JsonConvert.DeserializeObject<RepoContent>(MemoryPackSerializer.Deserialize<string>(_RepoContentBytes));

        public MissionRepoData() { }

        public MissionRepoData(MissionRepo repo, string content)
        {
            Name = repo.Name;
            Endpoint = repo.Endpoint;
            _RepoContentBytes = MemoryPackSerializer.Serialize(content);
        }
    }

    public static class MissionRepoDataExtension
    {
        public static IEnumerable<string> GetMissionDownloadUrls(
            this IQueryable<MissionRepoData> repos, MissionOutline outline)
        {
            foreach (var repo in repos)
            {
                foreach (var mission in repo.RepoContent.Missions)
                {
                    if (mission.Name != outline.Name)
                        continue;

                    var url = repo.RepoContent.GetMissionDownloadUrl(outline);
                    if (url is not null)
                        yield return url;
                }
            }
        }
    }
}