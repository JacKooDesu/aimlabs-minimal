using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALM.Util.TabView
{
    public class TabContent : MonoBehaviour
    {
        public virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}