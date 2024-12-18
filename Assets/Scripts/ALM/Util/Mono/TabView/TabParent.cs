using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALM.Util.TabView
{
    public class TabParent : MonoBehaviour
    {
        [SerializeField]
        List<TabItem> _tabItems;

        [Space]

        [SerializeField]
        Color _tabActiveColor;
        [SerializeField]
        Color _tabInactiveColor;

        void Awake()
        {
            foreach (var tab in _tabItems)
            {
                tab.OnTabSelected.AddListener(() =>
                {
                    SetActiveTab(_tabItems.IndexOf(tab));
                });
            }
        }

        public virtual void SetActiveTab(int index)
        {
            for (int i = 0; i < _tabItems.Count; i++)
            {
                var tab = _tabItems[i];
                var active = i == index;

                tab.Renderer.color = active ? _tabActiveColor : _tabInactiveColor;
                tab.Content.SetActive(active);
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Update Children")]
        void UpdateChildren()
        {
            _tabItems = new List<TabItem>(GetComponentsInChildren<TabItem>());
        }
#endif
    }
}
