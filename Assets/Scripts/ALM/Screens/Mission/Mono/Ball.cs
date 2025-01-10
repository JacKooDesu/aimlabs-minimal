using System;
using ALM.Common;
using Unity.Mathematics;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class Ball : MonoBehaviour, IRaycastTarget, IManagedTickable
    {
        public int TypeIndex { get; set; }
        public Color Color
        {
            set
            {
                var renderer = GetComponent<Renderer>();
                renderer.material.color = value;
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

        public event Action<int> OnHitBy;
        public event Action OnHit;

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
    }
}
