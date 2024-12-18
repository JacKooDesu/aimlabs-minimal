using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace ALM.Screens.Base
{
    using Util;

    [JsonObject]
    public class CameraSetting
    {
        [JsonProperty("FOV")]
        public ValueTrigger<float> Fov { get; private set; }
    }
}
