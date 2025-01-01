using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Screens.Base;
using ALM.Screens.Base.Setting;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

namespace ALM.Screens.Mission
{
    using Common;
    public class FpsCamController : MonoBehaviour, IRaycaster, IManagedTickable
    {
        [SerializeField]
        float _mouseSensitivity = 100.0f;
        [SerializeField]
        float _clampAngle = 80.0f;

        [SerializeField]
        float _mouseDpi = 800f;

        float _rotY = 0.0f;
        float _rotX = 0.0f;

        Quaternion _originRot;

        [Inject]
        ControlSetting _controlSetting;
        [Inject]
        GameplaySetting _gameplaySetting;
        // [Inject]
        // CameraSetting _cameraSetting;
        [Inject]
        RaycasterService _raycasterService;

        public Action OnFire;

        #region IRaycaster
        public Vector3 Origin => transform.position;
        public Vector3 Direction => transform.forward;
        #endregion

        void Awake()
        {
            _originRot = transform.localRotation;

            OnFire += Fire;
        }

        public void Tick()
        {
            _rotY += Input.GetAxisRaw("Mouse Y") * _gameplaySetting.Sensitivity;
            _rotX += Input.GetAxisRaw("Mouse X") * _gameplaySetting.Sensitivity;

            var qY = Quaternion.AngleAxis(_rotY, Vector3.left);
            var qX = Quaternion.AngleAxis(_rotX, Vector3.up);

            transform.localRotation = _originRot * qX * qY;

            if (Input.GetKeyDown(_controlSetting.FireButton))
                OnFire?.Invoke();
        }

        void Fire()
        {
            _raycasterService.Cast(this);
        }

        public Action UpdateOverride = null;
    }
}
