using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class Ball : MonoBehaviour, IRaycastTarget
    {
        public Color Color
        {
            set
            {
                var renderer = GetComponent<Renderer>();
                renderer.material.color = value;
            }
        }

        public event Action<int> OnHitBy;
        public event Action OnHit;

        public void HitBy(int index)
        {
            OnHitBy?.Invoke(index);
            OnHit?.Invoke();
        }
    }
}
