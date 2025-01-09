using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEngine.Pool;

namespace ALM.Screens.Base
{
    public class AudioService
    {
        public ObjectPool<AudioSource> Pool { get; private set; }
        public List<AudioSource> _activeSources = new();

        public AudioService(AudioSetting audioSetting)
        {
            var mixer = Resources.Load<AudioMixer>("Audio/Mixer");

            Pool = new ObjectPool<AudioSource>(
                Create,
                Get,
                Release,
                Destroy);


            AudioSource Create()
            {
                var go = new GameObject("AudioSource");
                var source = go.AddComponent<AudioSource>();
                source.outputAudioMixerGroup = mixer.outputAudioMixerGroup;
                source.playOnAwake = false;
                source.loop = false;
                source.spatialBlend = 1;
                source.rolloffMode = AudioRolloffMode.Linear;
                source.maxDistance = 20;
                source.gameObject.SetActive(false);
                source.GetCancellationTokenOnDestroy()
                    .Register(() => _activeSources.Remove(source));
                return source;
            }

            void Get(AudioSource source)
            {
                source.gameObject.SetActive(true);
                _activeSources.Add(source);
            }

            void Release(AudioSource source)
            {
                source.gameObject.SetActive(false);
                _activeSources.Remove(source);
            }

            void Destroy(AudioSource source)
            {
                UnityEngine.Object.Destroy(source.gameObject);
            }
        }

        public void PlaySoundAtPos(
            AudioClip clip, Vector3 pos,
            Action<AudioSource> addtionSetting = null) =>
            PlaySoundAtPosAsync(clip, pos, addtionSetting).Forget();
        public async UniTask PlaySoundAtPosAsync(
            AudioClip clip, Vector3 pos,
            Action<AudioSource> addtionSetting = null)
        {
            var source = Pool.Get();
            source.clip = clip;
            source.transform.position = pos;
            addtionSetting?.Invoke(source);
            source.Play();
            await UniTask.WaitUntil(() =>
                !source.isPlaying &&
                source.time >= clip.length,
                cancellationToken: source.GetCancellationTokenOnDestroy());

            if (source is null)
                return;
            Pool.Release(source);
        }

        public void RegisterSource(AudioSource source)
        {
            _activeSources.Add(source);
            source.GetCancellationTokenOnDestroy()
                .Register(() => _activeSources.Remove(source));
        }

        public AudioSource BindTo(Transform parent)
        {
            var source = Pool.Get();
            source.transform.SetParent(parent, false);
            source.transform.localPosition = Vector3.zero;
            parent.gameObject.GetCancellationTokenOnDestroy()
                .ToUniTask()
                .Item1
                .GetAwaiter()
                .OnCompleted(() => Pool.Release(source));
            return source;
        }

        public void Pause()
        {
            _activeSources.ForEach(s => s.Pause());
        }
        public void Resume()
        {
            _activeSources.ForEach(s => s.UnPause());
        }
    }
}