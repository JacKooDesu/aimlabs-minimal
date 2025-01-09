using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ALM.Screens.Base
{
    [CreateAssetMenu(fileName = "AudioMapSO", menuName = "ALM/Audio Map")]
    public class AudioMapSO : ScriptableObject
    {
        [field: SerializeField]
        public AudioData[] AudioDatas { get; private set; }

        Dictionary<string, AudioClip> _audioMap;
        public bool TryGetClip(string key, out AudioClip clip) =>
            (_audioMap ??= AudioDatas.ToDictionary(x => x.Key, x => x.Clip))
                .TryGetValue(key, out clip);

        [Serializable]
        public struct AudioData
        {
            public string Key;
            public AudioClip Clip;
        }

#if UNITY_EDITOR
        [ContextMenu("Init Keys")]
        void InitKeys()
        {
            List<AudioData> datas = new(AudioDatas);

            var keys = Constants.Audio.AudioKeys();
            datas.AddRange(
                keys.Except(AudioDatas.Select(x => x.Key))
                    .Select(x => new AudioData { Key = x }));

            AudioDatas = datas.ToArray();
        }
#endif
    }
}
