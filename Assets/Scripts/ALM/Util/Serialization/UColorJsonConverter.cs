using UnityEngine;
using Newtonsoft.Json;
using System;

namespace ALM.Util.Serialization
{
    public class UColorJsonConverter : JsonConverter<Color>
    {
        public override Color ReadJson(
            JsonReader reader, Type objectType,
            Color existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return JsonConvert.DeserializeObject<_Color>(reader.Value as string);
        }

        public override void WriteJson(
            JsonWriter writer, Color value,
            JsonSerializer serializer)
        {
            _Color color = value;
            writer.WriteValue(JsonConvert.SerializeObject(color));
        }

        [JsonObject]
        struct _Color
        {
            [JsonProperty("r")]
            public float R { get; private set; }
            [JsonProperty("g")]
            public float G { get; private set; }
            [JsonProperty("b")]
            public float B { get; private set; }
            [JsonProperty("a")]
            public float A { get; private set; }

            public static implicit operator Color(_Color color) =>
                new Color(color.R, color.G, color.B, color.A);
            public static implicit operator _Color(Color color) =>
                new _Color
                {
                    R = color.r,
                    G = color.g,
                    B = color.b,
                    A = color.a
                };
        }
    }
}