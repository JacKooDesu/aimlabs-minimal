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

        ControlSetting _controlSetting;
        GameplaySetting _gameplaySetting;
        RaycasterService _raycasterService;
        [Inject]
        void _Inject(
            ControlSetting controlSetting,
            GameplaySetting gameplaySetting,
            RaycasterService raycasterService,
            MissionLoader.PlayableMission mission)
        {
            _controlSetting = controlSetting;
            _gameplaySetting = gameplaySetting;
            _raycasterService = raycasterService;

            _camera = GetComponent<Camera>();
            _camera.fieldOfView = _gameplaySetting.FOV;
            _gameplaySetting.OnChange += OnGamePlaySettingChange;

            _isTracking = mission.Outline.Type is Data.MissionOutline.MissionType.Tracking;
        }

        bool _isTracking;
        public Action OnFire;

        Camera _camera;

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

            if (_isTracking || Input.GetKeyDown(_controlSetting.FireButton))
                OnFire?.Invoke();
        }

        void Fire()
        {
            _raycasterService.Cast(this);
        }

        public Action UpdateOverride = null;

        void OnDestroy()
        {
            _gameplaySetting.OnChange -= OnGamePlaySettingChange;
        }

        void OnGamePlaySettingChange(string path)
        {
            if (path == nameof(GameplaySetting.FOV))
                _camera.fieldOfView = _gameplaySetting.FOV;
        }
    }
}
