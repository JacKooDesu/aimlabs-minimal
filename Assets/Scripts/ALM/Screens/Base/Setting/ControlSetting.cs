using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ALM.Screens.Base.Setting
{
    using Util;
    using Util.UIToolkitExtend;

    public class ControlSetting : IDataTarget
    {
        const string NAME = "control_setting.json";


        [JsonProperty("fire_button")]
        public KeyCode FireButton { get; private set; } = KeyCode.Mouse0;
        [JsonProperty("jump_button")]
        public KeyCode JumpButton { get; private set; } = KeyCode.Space;
        [JsonProperty("crouch_button")]
        public KeyCode CrouchButton { get; private set; } = KeyCode.LeftControl;
        [JsonProperty("forward_button")]
        public KeyCode ForwardButton { get; private set; } = KeyCode.W;
        [JsonProperty("backward_button")]
        public KeyCode BackwardButton { get; private set; } = KeyCode.S;
        [JsonProperty("left_button")]
        public KeyCode LeftButton { get; private set; } = KeyCode.A;
        [JsonProperty("right_button")]
        public KeyCode RightButton { get; private set; } = KeyCode.D;

        public event Action<string> OnChange;

        public static Util.UIToolkitExtend.Bindable[] GetBindable()
        {
            return new[]
            {
                Bindable.Create<KeybindElement.Bindalbe>("Fire Button", nameof(FireButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Jump Button", nameof(JumpButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Crouch Button", nameof(CrouchButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Forward Button", nameof(ForwardButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Backward Button", nameof(BackwardButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Left Button", nameof(LeftButton)),
                Bindable.Create<KeybindElement.Bindalbe>("Right Button", nameof(RightButton)),
            };
        }

        public static ControlSetting Load() =>
            FileIO.JLoad<ControlSetting>(Constants.SETTING_PATH, NAME, true);
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME);

        public void IsDirty(string path)
        {
            OnChange?.Invoke(path);
        }
    }
}