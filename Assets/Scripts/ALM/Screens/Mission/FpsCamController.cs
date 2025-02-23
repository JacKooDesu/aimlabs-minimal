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

    public interface IPlayer : IRaycaster, IRaycastTarget, IManagedTickable, IEntity
    {
        Action UpdateOverride { get; }
        void SetPosition(Vector3 position);
    }

    public class FpsCamController : MonoBehaviour, IPlayer
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
        IController _controller;
        ControlSetting _controlSetting;
        GameplaySetting _gameplaySetting;
        RaycasterService _raycasterService;
        [Inject]
        void _Inject(
            IController controller,
            ControlSetting controlSetting,
            GameplaySetting gameplaySetting,
            RaycasterService raycasterService,
            MissionLoader.PlayableMission mission,
            EntityService entityService)
        {
            _controller = controller;
            _controlSetting = controlSetting;
            _gameplaySetting = gameplaySetting;
            _raycasterService = raycasterService;

            _camera = GetComponent<Camera>();
            SetFov();
            _gameplaySetting.OnChange += OnGamePlaySettingChange;

            _controller.OnFire += Fire;

            entityService.Add(this);
        }

        Camera _camera;

        public event Action<int> OnHitBy;
        public event Action OnHit;

        #region IRaycaster
        public Vector3 Origin => transform.position;
        public Vector3 Direction => transform.forward;
        #endregion

        void Awake()
        {
            _originRot = transform.localRotation;
        }

        public void Tick()
        {
            transform.localRotation =
                _originRot * _controller.Qx() * _controller.Qy();
        }

        void Fire()
        {
            _raycasterService.Cast(this);
        }

        public Action UpdateOverride { get; set; }
        public IEntityId Id { get; set; }

        void OnDestroy()
        {
            _gameplaySetting.OnChange -= OnGamePlaySettingChange;
        }

        void OnGamePlaySettingChange(string path)
        {
            if (path == nameof(GameplaySetting.FOV))
                SetFov();
        }

        void SetFov()
        {
            _camera.fieldOfView = Camera.HorizontalToVerticalFieldOfView(_gameplaySetting.FOV, 16f / 9f);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void HitBy(int index)
        {
            throw new NotImplementedException();
        }
    }
}
