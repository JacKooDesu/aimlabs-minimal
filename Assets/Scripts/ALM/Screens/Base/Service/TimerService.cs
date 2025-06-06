using System;
using System.Collections.Generic;
using System.Linq;
using ALM.Common;
using Unity.Mathematics;

namespace ALM.Screens.Base
{
    // public class TimerFactory
    // {
    //     public TimerFactory() { }

    //     public Timer Create(float duration) =>
    //         new(duration);
    // }

    public class Timer : IDisposable, IManagedConstTickable, IManagedTickable
    {
        readonly float _duration;
        float _elapsedTime;
        float _secCounter;
        bool _paused;
        public event Action OnComplete;
        public event Action<float> OnUpdate;
        public event Action<int> OnUpdateInt;

        public Timer(float duration)
        {
            _duration = duration;
            _elapsedTime = duration;
        }

        public void Reset()
        {
            _elapsedTime = _duration;
            _secCounter = 0;

            OnUpdate?.Invoke(_elapsedTime);
            InvokeInt();
        }

        public void Pause() =>
            _paused = true;
        public void Resume() =>
            _paused = false;

        /// <summary>
        /// Auto added deltaTime from UnityEngine.Time
        /// </summary>
        public void Tick()
        {
            if (_paused)
                return;

            Tick(UnityEngine.Time.deltaTime);
        }

        void Tick(float deltaTime)
        {
            _elapsedTime -= deltaTime;
            if (_elapsedTime <= 0)
            {
                OnComplete?.Invoke();
                return;
            }

            OnUpdate?.Invoke(_elapsedTime);

            if (OnUpdateInt is null)
                return;

            _secCounter += deltaTime;
            if (_secCounter < 1)
                return;

            while (_secCounter >= 1)
                _secCounter -= 1;

            InvokeInt();
        }

        void InvokeInt()
        {
            OnUpdateInt?.Invoke((int)math.ceil(_elapsedTime));
        }

        public void Dispose()
        {
            OnComplete = null;
            OnUpdate = null;
            OnUpdateInt = null;
        }
    }
}