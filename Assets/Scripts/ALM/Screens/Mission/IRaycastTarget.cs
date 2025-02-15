using System;
using ALM.Util.EventBinder;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public interface IRaycastTarget
    {
        event Action<int> OnHitBy;
        event Action OnHit;

        void HitBy(int index);
    }

    public class AnomoyousRaycastTarget : CollideBasedHandler, IRaycastTarget
    {
        public event Action<int> OnHitBy;
        public event Action OnHit;

        public void Setup(GameObject target, bool autoSetup = false) =>
            Setup<AnomoyousRaycastTarget>(target, autoSetup);

        public void HitBy(int index)
        {
            OnHitBy?.Invoke(index);
            OnHit?.Invoke();
        }
    }
}