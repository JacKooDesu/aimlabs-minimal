using System.Collections.Generic;
using Newtonsoft.Json;

namespace ALM.Data
{
    [JsonObject]
    public class MissionRepo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }

    [JsonObject]
    public class MissionRepoList
    {
        [JsonProperty("repos")]
        public MissionRepo[] Repos { get; private set; }
    }

    [JsonObject]
    public class RepoContent
    {
        [JsonProperty("download_api")]
        public string DownloadApi { get; private set; }

        [JsonProperty("missions")]
        public MissionOutline[] Missions { get; private set; }
    }
}