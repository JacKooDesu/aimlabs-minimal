using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using VContainer;
using UnityEngine;

namespace ALM.Screens.Base
{
    using ALM.Util;
    using ALM.Util.UIToolkitExtend;
    using ALM.Util.UIToolkitExtend.Elements;
    using static Util.UIToolkitExtend.DataBinder;

    [JsonObject]
    public class AudioSetting
    {
        const string NAME = "audio_setting.json";

        [JsonProperty("audio_clips")]
        Dictionary<string, string> _AudioClips { get; set; } = Constants.Audio
            .AudioKeys()
            .ToDictionary(x => x, _ => string.Empty);

        [Inject]
        readonly AudioMapSO _audioMapSO;

        public abstract record Clip();
        public record BuiltinClip(AudioClip Clip) : Clip();
        public record ExternalClip(string Path) : Clip();

        public Clip GetAudioClip(string key)
        {
            if (_AudioClips.TryGetValue(key, out string path) &&
                !string.IsNullOrEmpty(path))
                return new ExternalClip(path);

            if (_audioMapSO.TryGetClip(key, out var clip))
                return new BuiltinClip(clip);

            return null;
        }

        public static AudioSetting Load() =>
            FileIO.JLoad<AudioSetting>(Constants.SETTING_PATH, NAME, true);
        public void Save() =>
            FileIO.JSave(this, Constants.SETTING_PATH, NAME);

        internal DataBinder.Bindable[] GetBindable()
        {
            List<DataBinder.Bindable> list = new();

            list.AddRange(
                CollectionBinder.Dictionary<
                    AudioSetting, TextField,
                    UnityEngine.UIElements.TextField, string>(
                        this, "", nameof(_AudioClips)));

            return list.ToArray();
        }
    }
}
