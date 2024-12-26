using UnityEngine;

namespace ALM.Screens.Mission
{
    public interface IRaycaster
    {
        Vector3 Origin { get; }
        Vector3 Direction { get; }
    }
}