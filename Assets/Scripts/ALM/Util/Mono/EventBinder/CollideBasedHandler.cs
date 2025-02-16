using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ALM.Util.EventBinder
{
    public abstract class CollideBasedHandler : MonoBehaviour
    {
        public enum AutoConfig
        {
            None,
            Bound,

        }

        protected static T Setup<T>(GameObject target, bool autoSetup = false)
            where T : CollideBasedHandler
        {
            if (!target.TryGetComponent<Collider>(out var collider))
            {
                if (!autoSetup)
                {
                    Debug.Log($"[Collide Based Handler] {target} not attach collider!");
                    return null;
                }

                var box = target.AddComponent<BoxCollider>();
                Bounds bounds = new(target.transform.position, Vector3.zero);
                foreach (var render in target.GetComponentsInChildren<Renderer>())
                    bounds.Encapsulate(render.bounds);
                bounds.center = target.transform.InverseTransformPoint(bounds.center);
                box.size = bounds.size;
                box.center = bounds.center;

                collider = box;
            }

            var result = target.AddComponent<T>();
            result?.AfterSetup(collider);

            return result;
        }

        protected virtual void AfterSetup(Collider collider) { }
    }
}