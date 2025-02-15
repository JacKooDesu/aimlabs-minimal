using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Util.EventBinder
{
    public class TriggerEventHandler : CollideBasedEventHandler
    {
        protected override Type TargetType() => typeof(TriggerEventHandler);
        protected override void AfterSetup(Collider collider)
        {
            collider.isTrigger = true;
        }
        public static CollisionEventHandler Setup(GameObject target, bool autoSetup = false) =>
            Setup<CollisionEventHandler>(target, autoSetup);

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