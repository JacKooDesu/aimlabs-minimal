using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class RaycasterService
    {
        public event Action<IRaycaster> OnCastBegin;
        public event Action<IRaycaster, IRaycastTarget> OnCastFinished;
        public void Cast(IRaycaster raycaster)
        {
            OnCastBegin?.Invoke(raycaster);
            _Cast(raycaster.Origin, raycaster.Direction, out var target);
            OnCastFinished?.Invoke(raycaster, target);
        }

        public void CastOverride(IRaycaster raycaster, Vector3 origin, Vector3 direction)
        {
            OnCastBegin?.Invoke(raycaster);
            _Cast(origin, direction, out var target);
            OnCastFinished?.Invoke(raycaster, target);
        }

        void _Cast(in Vector3 origin, in Vector3 direction, out IRaycastTarget target)
        {
            target = default;
            if (Physics.Raycast(
                origin,
                direction,
                out var hit))
            {
                if (hit.transform.TryGetComponent<IRaycastTarget>(out target))
                {
                    target.HitBy(0);
                }
            }
        }
    }
}