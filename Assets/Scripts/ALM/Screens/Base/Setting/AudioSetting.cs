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
    using Cysharp.Threading.Tasks;
    using static Util.UIToolkitExtend.DataBinder;

    [JsonObject]
    public class AudioSetting
    {
        const string NAME = "audio_setting.json";

        [JsonProperty("audio_clips")]
        Dictionary<string, string> _AudioClips { get; set; } = Constants.Audio
            .AudioKeys()
            .ToDictionary(x => x, _ => string.Empty);

        [JsonIgnore]
        string[] _valueDirtyCheck;

        [JsonIgnore]
        Dictionary<string, AudioClip> _OverrideClips { get; set; } = new();

        [Inject]
        readonly AudioMapSO _audioMapSO;

        public void GetAudioClipSync(string key, Action<AudioClip> cb) =>
            GetAudioClipAsync(key)
                .ContinueWith(r => cb?.Invoke(r))
                .Forget();

        public async UniTask<AudioClip> GetAudioClipAsync(string key)
        {
            AudioClip clip;
            if (_AudioClips.TryGetValue(key, out string path) &&
                !string.IsNullOrEmpty(path))
            {
                if (_OverrideClips.TryGetValue(key, out clip))
                    return clip;

                if (clip = await FileIO.LoadExternalSoundAsync(
                        FileIO.GetPath(Constants.CUSTOMIZE_PATH, path)))
                    return _OverrideClips[key] = clip;
            }


            if (_audioMapSO.TryGetClip(key, out clip))
                return clip;

            return null;
        }

        public static AudioSetting Load()
        {
            var s = FileIO.JLoad<AudioSetting>(Constants.SETTING_PATH, NAME, true);
            s._valueDirtyCheck = s._AudioClips.Values.ToArray();
            return s;
        }
        public void Save()
        {
            FileIO.JSave(this, Constants.SETTING_PATH, NAME);

            var newValues = _AudioClips.Values.ToArray();
            for (int i = 0; i < _valueDirtyCheck.Length; i++)
            {
                if (_valueDirtyCheck[i] != newValues[i])
                    _OverrideClips.Remove(_AudioClips.Keys.ElementAt(i));
            }
            _valueDirtyCheck = newValues;
        }

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
