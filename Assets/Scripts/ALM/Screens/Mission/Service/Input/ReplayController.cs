using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Data;
    using Unity.Mathematics;

    public class ReplayController : IController, IManagedTickable
    {
        readonly ReplayPlayerService _replayer;
        readonly RaycasterService _raycasterService;

        float2 _rotTemp;

        public float RotX { get; private set; }
        public float RotY { get; private set; }
        public float2 MouseDelta => _mouseDelta;
        public float2 _mouseDelta;

        public event Action OnFire;

        float _renderTime = 0.0f;

        public ReplayController(
            ReplayPlayerService replayer,
            RaycasterService raycasterService)
        {
            _raycasterService = raycasterService;
            _replayer = replayer;

            _replayer.OnUpdateInput += UpdateInput;
        }

        public void Tick()
        {
            var delta = math.lerp(
                0, _mouseDelta,
                UnityEngine.Time.deltaTime / UnityEngine.Time.fixedDeltaTime);

            RotX += delta.x;
            RotY += delta.y;

            // if (_currentFrame is 0)
            //     return;

            // _renderTime += UnityEngine.Time.deltaTime;
            // if (_renderTime >= UnityEngine.Time.fixedDeltaTime)
            //     _renderTime -= UnityEngine.Time.fixedDeltaTime;
        }

        void UpdateInput(InputFrame frame)
        {
            RotX = _rotTemp.x;
            RotY = _rotTemp.y;

            _rotTemp = new float2(RotX, RotY) + frame.MouseDelta;
            _mouseDelta = frame.MouseDelta;
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotY, Vector3.left);
    }
}