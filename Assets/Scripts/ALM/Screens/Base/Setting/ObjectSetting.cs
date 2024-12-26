using System;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
    using ALM.Util.UIToolkitExtend;
    using Util;
    using static Util.UIToolkitExtend.DataBinder;


    [JsonObject]
    public class ObjectSetting
    {
        const string NAME = "object_setting.json";

        [JsonProperty("ball_colors")]
        _Color[] _ballColors = new _Color[]
        {
            Color.red,
            Color.green,
            Color.blue
        };
        [JsonProperty("room_texture")]
        public string RommTextureName { get; private set; } = "";
        [JsonProperty("room_texture_scaler")]
        public float RoomTextureScale { get; private set; } =
            Room.DEFAULT_TEXTURE_SCALER;

        public Color GetBallColor(int index) =>
            _ballColors[index];

        public Texture2D GetRoomTexture() =>
            FileIO.LoadTexture(RommTextureName);

        public static ObjectSetting Load() =>
            FileIO.JLoad<ObjectSetting>(Constants.SETTING_PATH, NAME, true);
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME);

        internal static DataBinder.Bindable[] GetBindable() => new Bindable[]
        {
            Bindable.Create<TextField>("Room Texture Name", nameof(RommTextureName)),
            Bindable.Create<FloatField>("Room Texture Scaler", nameof(RoomTextureScale)),
        };



        [JsonObject]
        public class _Color
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