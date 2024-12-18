using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class FpsCamController : MonoBehaviour
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

        void Awake()
        {
            _originRot = transform.localRotation;
        }

        void Update()
        {
            _rotY += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
            _rotX += Input.GetAxisRaw("Mouse X") * _mouseSensitivity;

            var qY = Quaternion.AngleAxis(_rotY, Vector3.left);
            var qX = Quaternion.AngleAxis(_rotX, Vector3.up);

            transform.localRotation = _originRot * qX * qY;
        }
    }
}
