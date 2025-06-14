using System.Collections.Generic;
using Newtonsoft.Json;

namespace ALM.Data
{
    [JsonObject]
    public class MissionSourceContentResponse
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("missions")]
        public List<Mission> Missions { get; private set; }

        [JsonObject]
        public class Mission
        {
            [JsonProperty("name")]
            public string Name { get; private set; }
            [JsonProperty("author")]
            public string Author { get; private set; }
            [JsonProperty("detail_url")]
            public string DetailUrl { get; private set; }
        }
    }

    [JsonObject]
    public class MissionDetailResponse
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("author")]
        public string Author { get; private set; }
        [JsonProperty("version")]
        public string Version { get; private set; }
        [JsonProperty("git_url")]
        public string GitUrl { get; private set; }
        [JsonProperty("archive_url")]
        public string ArchiveUrl { get; private set; }

        [JsonProperty("info")]
        public MissionOutline Info { get; private set; }
    }
}