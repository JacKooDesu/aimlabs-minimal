using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
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
        public Color[] BallColors = new Color[]
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

        internal static DataBinder.Bindable[] GetBindable() => new Bindable[]
        {
            Bindable.Create<TextField>("Room Texture Name", nameof(RommTextureName)),
            Bindable.Create<FloatField>("Room Texture Scaler", nameof(RoomTextureScale)),
            Bindable.Create<BindableFlatArr<ColorBindElement.Bindalbe, ColorBindElement, Color>>(
                    "Ball Colors",
                    nameof(BallColors))
        };
    }
}