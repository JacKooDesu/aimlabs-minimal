using Newtonsoft.Json;

namespace ALM.Data
{
    [JsonObject]
    public class MissionOutline
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("author")]
        public string Author { get; private set; }

        [JsonProperty("map")]
        public string Map { get; private set; }
        [JsonProperty("map_size")]
        public float MapSize { get; private set; }

        [JsonProperty("time_seconds")]
        public int Time { get; private set; }
    }
}