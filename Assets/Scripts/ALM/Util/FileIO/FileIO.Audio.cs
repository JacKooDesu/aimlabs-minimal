using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;

namespace ALM.Util
{
    public static partial class FileIO
    {
        public static void LoadExternalSoundSync(
            string path, Action<AudioClip> cb, CancellationToken ct = default) =>
            LoadExternalSoundAsync(path, ct)
                .ContinueWith(r => cb(r)).Forget();

        public static async UniTask<AudioClip> LoadExternalSoundAsync(
            string path, CancellationToken ct = default)
        {
            var type = Path.GetExtension(path) switch
            {
                "mp3" => AudioType.MPEG,
                "ogg" => AudioType.OGGVORBIS,
                "wav" => AudioType.WAV,
                _ => AudioType.UNKNOWN
            };

            AudioClip clip = null;

            try
            {
                using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, type))
                {
                    clip = await www.SendWebRequest()
                        .ToUniTask(cancellationToken: ct)
                        .ContinueWith(r => r.result switch
                        {
                            UnityWebRequest.Result.Success =>
                               DownloadHandlerAudioClip.GetContent(r),
                            _ => throw new System.Exception("Failed to load audio!")
                        });
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return clip;
        }
    }
}