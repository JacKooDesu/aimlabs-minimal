using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class MonoCommander : MonoBehaviour
    {
        // Position
        Commander<Vector3> PositionCommander =>
            _positionCommander ??= new Action<Vector3>(
                v3 => transform.position = v3).ToCommander();
        Commander<Vector3> _positionCommander;

        // Rotation
        Commander<Vector3> RotationCommander =>
            _rotationCommander ??= new Action<Vector3>(
                v3 => transform.rotation = Quaternion.Euler(v3)).ToCommander();
        Commander<Vector3> _rotationCommander;

        // Scale
        Commander<Vector3> ScaleCommander =>
            _scaleCommander ??= new Action<Vector3>(
                v3 => transform.localScale = v3).ToCommander();
        Commander<Vector3> _scaleCommander;

        public ICommand Translate(Vector3 value) =>
            new Vector3Command(value, _positionCommander);

        public ICommand Rotate(Vector3 value) =>
            new Vector3Command(value, _rotationCommander);
    }
}