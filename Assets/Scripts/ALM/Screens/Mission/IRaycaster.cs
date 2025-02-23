using UnityEngine;

namespace ALM.Screens.Mission
{
    public interface IRaycaster : IEntity
    {
        Vector3 Origin { get; }
        Vector3 Direction { get; }
    }
}