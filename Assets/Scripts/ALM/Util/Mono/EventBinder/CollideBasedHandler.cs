using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ALM.Util.EventBinder
{
    public abstract class CollideBasedHandler : MonoBehaviour
    {
        Collider _collider;
        public Collider Collider => _collider;

        public enum AutoConfig
        {
            None,
            Bound,
            Mesh,
        }

        protected static T Setup<T>(GameObject target, AutoConfig autoSetup = AutoConfig.None)
            where T : CollideBasedHandler
        {
            if (!target.TryGetComponent<Collider>(out var collider))
            {
                if (autoSetup is AutoConfig.None)
                {
                    Debug.Log($"[Collide Based Handler] {target} not attach collider!");
                    return null;
                }

                collider = autoSetup switch
                {
                    AutoConfig.Bound => ConfigByBound(target.transform),
                    AutoConfig.Mesh => ConfigByMesh(target.transform),
                    _ => throw new NotImplementedException(),
                };
            }

            var result = target.AddComponent<T>();
            result?.AfterSetup(collider);
            result._collider = collider;

            return result;
        }

        static Collider ConfigByBound(Transform target)
        {
            var box = target.gameObject.AddComponent<BoxCollider>();

            Bounds bounds = new(target.position, Vector3.zero);
            foreach (var render in target.GetComponentsInChildren<Renderer>())
                bounds.Encapsulate(render.bounds);
            bounds.center = target.transform.InverseTransformPoint(bounds.center);
            box.size = bounds.size;
            box.center = bounds.center;

            return box;
        }

        static Collider ConfigByMesh(Transform target)
        {
            var meshCol = target.gameObject.AddComponent<MeshCollider>();
            meshCol.sharedMesh = target.GetComponent<MeshFilter>().sharedMesh;
            return meshCol;
        }
        protected virtual void AfterSetup(Collider collider) { }
    }
}