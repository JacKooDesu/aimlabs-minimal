using System.Collections.Generic;
using MemoryPack;
using Newtonsoft.Json;

namespace ALM.Data
{
    [JsonObject]
    public class MissionSourceConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
    }

    [JsonObject]
    public class MissionSourceList
    {
        [JsonProperty("sources")]
        public string[] Sources { get; private set; }
    }
}