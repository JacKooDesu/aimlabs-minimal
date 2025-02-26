using System;
using ALM.Common;
using Unity.Mathematics;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class Ball : MonoCommander, IRaycastTarget, IManagedTickable
    {
        public int TypeIndex { get; set; }
        public Color Color
        {
            set
            {
                foreach (var x in GetComponentsInChildren<Renderer>())
                    x.material.color = value;
            }
        }

        public float Hp
        {
            get => _hpBar?.Value ?? 0;
            set
            {
                if (_hpBar is null)
                    return;
                _hpBar.Value = value;
            }
        }

        public IEntityId Id { get; set; }

        public event Action<int> OnHitBy;
        public event Action OnHit;

        // FIXME: height offset need fix
        HpBar _hpBar;

        public void Tick()
        {
            if (!gameObject.activeInHierarchy)
                return;
        }

        public void HitBy(int index)
        {
            OnHitBy?.Invoke(index);
            OnHit?.Invoke();
        }

        public Ball HasHpBar()
        {
            _hpBar = new GameObject("hp bar")
                .AddComponent<HpBar>();
            _hpBar.transform.SetParent(transform);
            _hpBar.transform.localPosition = Vector3.up;

            Hp = 1f;

            return this;
        }

        public static Ball Create(GameObject target, AnomoyousRaycastTarget raycastTarget)
        {
            var ball = target.gameObject.AddComponent<Ball>();

            raycastTarget.OnHit += () => ball.OnHit?.Invoke();
            raycastTarget.OnHitBy += i => ball.OnHitBy?.Invoke(i);

            return ball;
        }
    }
}
