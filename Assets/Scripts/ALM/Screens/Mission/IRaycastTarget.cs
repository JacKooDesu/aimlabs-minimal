using System;

namespace ALM.Screens.Mission
{
    public interface IRaycastTarget
    {
        event Action<int> OnHitBy;
        event Action OnHit;

        void HitBy(int index);
    }
}