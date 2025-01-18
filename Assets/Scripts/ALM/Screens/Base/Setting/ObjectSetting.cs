using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
    using ALM.Util.Serialization;
    using ALM.Util.UIToolkitExtend;
    using ALM.Util.UIToolkitExtend.Elements;
    using Util;
    using static Util.UIToolkitExtend.DataBinder;

    using IMAGE_FILE = Util.FileIO.File<
        Util.FileIO.Compose<
            Util.FileIO.PNG,
            Util.FileIO.JPG>>;

    [JsonObject]
    public class ObjectSetting : IDataTarget
    {
        const string NAME = "object_setting.json";

        [JsonProperty("ball_colors")]
        Color[] BallColors { get; set; } = new Color[]
        {
            Color.red,
            Color.green,
            Color.blue
        };
        public string GetBallColorPath(int index) =>
            nameof(BallColors) + $"[{index}]";

        [JsonProperty("room_texture")]
        public IMAGE_FILE RoomTextureName { get; private set; } = new("");
        [JsonProperty("room_texture_scaler")]
        public float RoomTextureScale { get; private set; } =
            Room.DEFAULT_TEXTURE_SCALER;

        public event Action<string> OnChange;

        public Color GetBallColor(int index) =>
            BallColors[index];

        public Texture2D GetRoomTexture() =>
            FileIO.LoadTexture(Constants.CUSTOMIZE_PATH, RoomTextureName.path);

        public static ObjectSetting Load() =>
            FileIO.JLoad<ObjectSetting>(Constants.SETTING_PATH, NAME, true, new UColorJsonConverter());
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME, new UColorJsonConverter());

        internal Bindable[] GetBindable()
        {
            List<Bindable> list = new()
            {
                Bindable.Create<FileInputElement.Bindable>("Room Texture Name", nameof(RoomTextureName)),
                Bindable.Create<OriginBindalbe.FloatField>("Room Texture Scaler", nameof(RoomTextureScale)),
            };

            list.AddRange(
                CollectionBinder.Array<
                    ObjectSetting, ColorBindElement.Bindable, ColorBindElement, Color>(
                    this, "Ball Colors", nameof(BallColors)));

            return list.ToArray();
        }

        public void IsDirty(string path)
        {
            OnChange?.Invoke(path);
        }
    }
}