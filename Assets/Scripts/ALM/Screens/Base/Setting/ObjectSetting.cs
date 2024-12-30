using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
    using System.Linq;
    using ALM.Util.Serialization;
    using ALM.Util.UIToolkitExtend;
    using ALM.Util.UIToolkitExtend.Elements;
    using Util;
    using static Util.UIToolkitExtend.DataBinder;


    [JsonObject]
    public class ObjectSetting
    {
        const string NAME = "object_setting.json";

        [JsonProperty("ball_colors")]
        Color[] BallColors { get; set; } = new Color[]
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
            BallColors[index];

        public Texture2D GetRoomTexture() =>
            FileIO.LoadTexture(RommTextureName);

        public static ObjectSetting Load() =>
            FileIO.JLoad<ObjectSetting>(Constants.SETTING_PATH, NAME, true, new UColorJsonConverter());
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME, new UColorJsonConverter());

        internal Bindable[] GetBindable()
        {
            List<Bindable> list = new()
            {
                Bindable.Create<TextField>("Room Texture Name", nameof(RommTextureName)),
                Bindable.Create<FloatField>("Room Texture Scaler", nameof(RoomTextureScale)),
            };

            list.AddRange(
                CollectionBinder.Array<
                    ObjectSetting, ColorBindElement.Bindalbe, ColorBindElement, Color>(
                    this, "Ball Colors", nameof(BallColors)));

            return list.ToArray();
        }
    }
}