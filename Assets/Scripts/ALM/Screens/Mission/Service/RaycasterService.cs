using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class RaycasterService
    {
        public event Action OnCastBegin;
        public event Action<IRaycastTarget> OnCastFinished;
        public void Cast(IRaycaster raycaster)
        {
            OnCastBegin?.Invoke();

            IRaycastTarget target = default;
            if (Physics.Raycast(
                raycaster.Origin,
                raycaster.Direction,
                out var hit))
            {
                if (hit.transform.TryGetComponent<IRaycastTarget>(out target))
                {
                    target.HitBy(0);
                }
            }
            OnCastFinished?.Invoke(target);
        }
    }
}