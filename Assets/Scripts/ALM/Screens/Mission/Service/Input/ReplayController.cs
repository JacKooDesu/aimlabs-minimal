using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base.Setting;

    public class ReplayController : IController, IManagedFixedTickable
    {
        readonly Replay _replay;
        readonly RaycasterService _raycasterService;
        int _currentFrame = 0;

        public float RotX { get; private set; }
        public float RotY { get; private set; }

        public event Action OnFire;

        public ReplayController(
            Replay replay,
            RaycasterService raycasterService)
        {
            _replay = replay;
            _raycasterService = raycasterService;
        }

        public void FixedTick()
        {
            if (_currentFrame >= _replay.InputFrames.Count)
                return;

            if (_replay.CastFrames.TryGetValue(_currentFrame, out var cf))
                // FIXME: null here?
                _raycasterService.CastOverride(
                    null, cf.Origin, cf.Direction);

            var frame = _replay.InputFrames[_currentFrame];

            RotX = frame.RotX;
            RotY = frame.RotY;

            _currentFrame++;
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotY, Vector3.left);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
    }
}