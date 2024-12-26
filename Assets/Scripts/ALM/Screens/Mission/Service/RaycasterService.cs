using UnityEngine;

namespace ALM.Screens.Mission
{
    public class RaycasterService
    {
        public void Cast(IRaycaster raycaster)
        {
            if (Physics.Raycast(
                raycaster.Origin,
                raycaster.Direction,
                out var hit))
            {
                if(hit.transform.TryGetComponent<IRaycastTarget>(out var target))
                {
                    target.HitBy(0);
                }
            }
        }
    }
}