using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
    using Util.UIToolkitExtend;
    using Util;
    using static Util.UIToolkitExtend.DataBinder;
    using IMAGE_FILE = Util.FileIO.File<
        Util.FileIO.Compose<
            Util.FileIO.PNG,
            Util.FileIO.JPG>>;
    using ALM.Util.UIToolkitExtend.Elements;
    using UnityEngine.UIElements;

    [JsonObject]
    public class GameplaySetting : IDataTarget
    {
        const string NAME = "gameplay_setting.json";


        [JsonProperty("sensitivity")]
        public float Sensitivity { get; private set; } = 1.0f;
        [JsonProperty("invertY")]
        public bool InvertY { get; private set; } = false;
        [JsonProperty("invertX")]
        public bool InvertX { get; private set; } = false;
        [JsonProperty("fov")]
        public float FOV { get; private set; } = 60.0f;

        [JsonProperty("crosshair")]
        public IMAGE_FILE Crosshair { get; private set; } = new("");

        public event Action<string> OnChange;

        public Util.UIToolkitExtend.Bindable[] GetBindable()
        {
            List<Bindable> bindable = new()
            {
                Bindable.Create<OriginBindalbe.FloatField>("Sensitivity", nameof(Sensitivity)),
                Bindable.Create<OriginBindalbe.Toggle>("Invert Y", nameof(InvertY)),
                Bindable.Create<OriginBindalbe.Toggle>("Invert X", nameof(InvertX)),
                Bindable.Create<OriginBindalbe.FloatField>("FOV", nameof(FOV)),
            };

            var crosshair = Bindable.Create<FileInputElement.Bindable>("Crosshair", nameof(Crosshair));
            crosshair.AfterBuild += SetCorsshairFileInput;
            bindable.Add(crosshair);

            return bindable.ToArray();
        }

        public static GameplaySetting Load() =>
            FileIO.JLoad<GameplaySetting>(Constants.SETTING_PATH, NAME, true);
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME);

        public void IsDirty(string path)
        {
            OnChange?.Invoke(path);
        }

        void SetCorsshairFileInput(BindableElement element)
        {
            if (element is FileInputElement fe)
            {
                fe.DefaultRootPath =
                    FileIO.GetPath(Constants.CROSSHAIR_PATH);
                fe.FileProcessor = f => FileIO.CopyFileProcessor(fe.value, f);
            }
        }
    }
}
