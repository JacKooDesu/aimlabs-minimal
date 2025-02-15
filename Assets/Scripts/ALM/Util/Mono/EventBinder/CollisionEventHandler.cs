using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Util.EventBinder
{
    public class CollisionEventHandler : CollideBasedEventHandler
    {
        protected override Type TargetType() => typeof(CollisionEventHandler);

        public static CollisionEventHandler Setup(GameObject target, bool autoSetup = false) =>
            Setup<CollisionEventHandler>(target, autoSetup);

        public CollisionEventHandler Register<T>(
            Timing timing,
            UnityAction<T> action) where T : Component =>
            Register(this, timing, action);

        void OnCollisionEnter(Collision other) =>
            Check(Timing.Enter, other.gameObject.TryGetComponent);

        void OnCollisionExit(Collision other) =>
            Check(Timing.Exit, other.gameObject.TryGetComponent);

        void OnCollisionStay(Collision other) =>
            Check(Timing.Stay, other.gameObject.TryGetComponent);
    }
}