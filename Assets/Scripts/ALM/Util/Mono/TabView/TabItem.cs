using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ALM.Util.TabView
{
    public class TabItem : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent OnTabSelected { get; } = new();
        [field: SerializeField]
        public Graphic Renderer { get; private set; }
        [field: SerializeField]
        public TabContent Content { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTabSelected?.Invoke();
        }
    }
}