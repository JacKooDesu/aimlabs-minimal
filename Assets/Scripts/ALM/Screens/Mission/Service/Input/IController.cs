using System;
using UnityEngine;

namespace ALM.Screens.Mission.Service
{
    using Common;

    interface IController
    {
        public event Action OnFire;

        public float RotX { get; }
        public float RotY { get; }

        public Quaternion Qx();
        public Quaternion Qy();
    }
}