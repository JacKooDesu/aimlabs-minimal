using System;
using Unity.Mathematics;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public interface IController
    {
        public event Action OnFire;

        public float RotX { get; }
        public float RotY { get; }

        public float2 MouseDelta { get; }

        public Quaternion Qx();
        public Quaternion Qy();
    }
}