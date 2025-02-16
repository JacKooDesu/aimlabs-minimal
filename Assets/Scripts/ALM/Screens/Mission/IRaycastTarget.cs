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

        public static AnomoyousRaycastTarget Setup(GameObject target, AutoConfig autoConfig = AutoConfig.None) =>
            Setup<AnomoyousRaycastTarget>(target, autoConfig);

        public void HitBy(int index)
        {
            OnHitBy?.Invoke(index);
            OnHit?.Invoke();
        }
    }
}