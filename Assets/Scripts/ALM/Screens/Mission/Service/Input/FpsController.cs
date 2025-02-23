using System;
using UnityEngine;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base.Setting;

    public class FpsController : IController, IManagedTickable, IManagedFixedTickable
    {
        readonly GameplaySetting _gameplaySetting;
        readonly ControlSetting _controlSetting;

        public event Action OnFire;

        public float RotX { get; private set; } = 0.0f;
        public float RotY { get; private set; } = 0.0f;

        public float2 _mouseDelta;
        public float2 MouseDelta => _mouseDelta;

        bool _keepFireMode;

        public FpsController(
            GameplaySetting gameplaySetting,
            ControlSetting controlSetting,
            bool keepFireMode = false)
        {
            _gameplaySetting = gameplaySetting;
            _controlSetting = controlSetting;
            _keepFireMode = keepFireMode;
        }

        public void Tick()
        {
            _mouseDelta = GetMouseDelta();
            
            RotY += _mouseDelta.y;
            RotX += _mouseDelta.x;

            if (_keepFireMode || Input.GetKeyDown(_controlSetting.FireButton))
                OnFire?.Invoke();
        }

        public void FixedTick() { }

        float2 GetMouseDelta()
        {
            var delta = new float2(
                Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y"));

            return delta * _gameplaySetting.Sensitivity;
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotY, Vector3.left);

    }
}