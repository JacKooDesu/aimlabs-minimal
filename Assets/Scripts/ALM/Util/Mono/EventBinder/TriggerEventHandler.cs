using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ALM.Util.EventBinder
{
    public class TriggerEventHandler : CollideEventHandler
    {
        protected override void AfterSetup(Collider collider)
        {
            collider.isTrigger = true;
        }
        public static CollisionEventHandler Setup(GameObject target, AutoConfig autoConfig = AutoConfig.None) =>
            Setup<CollisionEventHandler>(target, autoConfig);

        public TriggerEventHandler Register<T>(
            Timing timing,
            UnityAction<T> action) where T : Component =>
            Register(this, timing, action);

        void OnTriggerEnter(Collider other) =>
            Check(Timing.Enter, other.TryGetComponent);

        void OnTriggerExit(Collider other) =>
            Check(Timing.Exit, other.TryGetComponent);

        void OnTriggerStay(Collider other) =>
            Check(Timing.Stay, other.TryGetComponent);
    }
}