using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    [RequireComponent(typeof(VisualElement))]
    public class LinkedPages : MonoBehaviour
    {
        VisualElement _ui;

        [SerializeField, SerializeReference]
        List<Item> _items = new();
        [SerializeField]
        int _index = 0;

        [SerializeField]
        string _defaultActiveProperty = "active";
        [SerializeField]
        string _defaultInctiveProperty = "hide";

        [SerializeField]
        string _defaultLinkSuffix = "-Page";

        record ItemData(Item ItemSetting, VisualElement Item, VisualElement Page);
        List<ItemData> _itemDatas = new();

        void Awake()
        {
            _ui = GetComponent<UIDocument>().rootVisualElement;
        }

        void OnEnable()
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                var item = _items[i];
                var data = new ItemData(
                    item,
                    item.Bind(_ui, () => ChangePageAction(item)),
                    _ui.Q(PageName(item)));

                _itemDatas.Add(data);

                SetItemStatus(i, _index == i);
                SetPageStatus(i, _index == i);
            }
        }

        void ChangePageAction(Item item)
        {
            SetItemStatus(_index, false);
            SetPageStatus(_index, false);
            this._index = _items.IndexOf(item);
            SetItemStatus(_index, true);
            SetPageStatus(_index, true);
        }

        void SetItemStatus(int index, bool status)
        {
            if (status)
                _itemDatas[index].Item.AddToClassList(_defaultActiveProperty);
            else
                _itemDatas[index].Item.RemoveFromClassList(_defaultActiveProperty);
        }

        void SetPageStatus(int index, bool status)
        {
            var (add, remove) = status ?
                (_defaultActiveProperty, _defaultInctiveProperty) :
                (_defaultInctiveProperty, _defaultActiveProperty);

            _itemDatas[index].Page.RemoveFromClassList(remove);
            _itemDatas[index].Page.AddToClassList(add);
        }

        string PageName(Item item) => item.Name + _defaultLinkSuffix;

#if UNITY_EDITOR
        [ContextMenu("Add Button")]
        void AddBtn() => _items.Add(new ButtonItem());
#endif
        [Serializable]
        internal abstract class Item
        {
            [field: SerializeField]
            public string Name { get; private set; } = "Button";
            public abstract Type Type { get; }

            public abstract VisualElement Bind(VisualElement ui, Action action);
        }

        internal class ButtonItem : Item
        {
            public override Type Type => typeof(Button);
            public override VisualElement Bind(VisualElement ui, Action action)
            {
                var element = ui.Q<Button>(Name);
                element.clicked += action;
                return element;
            }
        }
    }
}
