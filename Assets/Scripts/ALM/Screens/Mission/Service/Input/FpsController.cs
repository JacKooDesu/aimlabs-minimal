using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Screens.Base.Setting;

    public class FpsController : IController, IManagedTickable
    {
        readonly GameplaySetting _gameplaySetting;
        readonly ControlSetting _controlSetting;

        public event Action OnFire;

        public float RotX { get; private set; } = 0.0f;
        public float RotY { get; private set; } = 0.0f;

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
            RotY += Input.GetAxisRaw("Mouse Y") * _gameplaySetting.Sensitivity;
            RotX += Input.GetAxisRaw("Mouse X") * _gameplaySetting.Sensitivity;

            if (_keepFireMode || Input.GetKeyDown(_controlSetting.FireButton))
                OnFire?.Invoke();
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotY, Vector3.left);
    }
}