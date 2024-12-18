using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALM.Util.UIToolkitExtend
{
    public class DefaultClassBinder : MonoBehaviour
    {
        [field: SerializeField]
        public string Active { get; private set; } = "active";
        [field: SerializeField]
        public string Inactive { get; private set; } = "hide";
    }
}
