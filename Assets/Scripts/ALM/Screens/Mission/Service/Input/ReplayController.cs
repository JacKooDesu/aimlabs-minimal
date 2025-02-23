using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base.Setting;
    using Unity.Mathematics;

    public class ReplayController : IController, IManagedTickable, IManagedFixedTickable
    {
        readonly Replay _replay;
        readonly RaycasterService _raycasterService;
        int _currentFrame = 0;

        public float RotX { get; private set; }
        public float RotY { get; private set; }
        public float2 MouseDelta => _mouseDelta;
        public float2 _mouseDelta;

        public event Action OnFire;

        float _renderTime = 0.0f;
        float _fixedTime = 0.0f;

        public ReplayController(
            Replay replay,
            RaycasterService raycasterService)
        {
            _replay = replay;
            _raycasterService = raycasterService;
        }

        public void FixedTick()
        {
            _fixedTime += UnityEngine.Time.fixedDeltaTime;

            if (_currentFrame >= _replay.InputFrames.Count)
                return;

            if (_replay.CastFrames.TryGetValue(_currentFrame, out var cf))
                // FIXME: null here?
                _raycasterService.CastOverride(
                    null, cf.Origin, cf.Direction);

            var frame = _replay.InputFrames[_currentFrame];
            _mouseDelta = frame.MouseDelta;

            RotX += frame.MouseDelta.x;
            RotY += frame.MouseDelta.y;

            _currentFrame++;
        }

        public void Tick()
        {
            // if (_currentFrame is 0)
            //     return;

            // _renderTime += UnityEngine.Time.deltaTime;
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotY, Vector3.left);
    }
}