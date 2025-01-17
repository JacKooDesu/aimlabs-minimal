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

        public FpsController(
            GameplaySetting gameplaySetting,
            ControlSetting controlSetting)
        {
            _gameplaySetting = gameplaySetting;
            _controlSetting = controlSetting;
        }

        public void Tick()
        {
            RotY += Input.GetAxisRaw("Mouse Y") * _gameplaySetting.Sensitivity;
            RotX += Input.GetAxisRaw("Mouse X") * _gameplaySetting.Sensitivity;

            if (Input.GetKeyDown(_controlSetting.FireButton))
                OnFire?.Invoke();
        }

        public Quaternion Qx() =>
            Quaternion.AngleAxis(RotY, Vector3.left);
        public Quaternion Qy() =>
            Quaternion.AngleAxis(RotX, Vector3.up);
    }
}