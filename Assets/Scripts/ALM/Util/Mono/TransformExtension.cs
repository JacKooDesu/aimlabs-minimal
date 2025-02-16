using UnityEngine;

namespace ALM.Util
{
    public static class TransformExtension
    {
        public static bool TryFind(this Transform transform, string name, out Transform result)
        {
            result = transform.Find(name);
            return result is not null;
        }
    }
}