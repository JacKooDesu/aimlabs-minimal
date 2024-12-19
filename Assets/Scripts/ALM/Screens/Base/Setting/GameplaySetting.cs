using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Screens.Base.Setting
{
    using static Util.UIToolkitExtend.DataBinder;
    [JsonObject]
    public class GameplaySetting
    {
        [JsonProperty("sensitivity")]
        public float Sensitivity { get; private set; } = 1.0f;
        [JsonProperty("invertY")]
        public bool InvertY { get; private set; } = false;
        [JsonProperty("invertX")]
        public bool InvertX { get; private set; } = false;

        public static Bindable[] GetBindable()
        {
            return new Bindable[]
            {
                Bindable.Create<FloatField>("Sensitivity", nameof(Sensitivity)),
                Bindable.Create<Toggle>("Invert Y", nameof(InvertY)),
                Bindable.Create<Toggle>("Invert X", nameof(InvertX)),
            };
        }
    }
}
