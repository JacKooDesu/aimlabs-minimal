using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Serialization;

namespace ALM.Data
{
    using ALM.Util;
    using MemoryPack;

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

        [JsonProperty("type")]
        public MissionType Type { get; private set; }

        [JsonProperty("version")]
        public string Version { get; private set; } = "v0.0.0";
        public int VersionInt => VersionChecker.VersionToInt(Version);

        public enum MissionType : int
        {
            [EnumMember(Value = "")]
            None,
            [EnumMember(Value = "flicking")]
            Flicking,
            [EnumMember(Value = "reaction")]
            Reaction,
            [EnumMember(Value = "tracking")]
            Tracking,
        }
    }
}