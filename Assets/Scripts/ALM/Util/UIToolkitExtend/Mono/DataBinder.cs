using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public class DataBinder : MonoBehaviour
    {
        VisualElement _ui;

        [SerializeField]
        public string Target { get; private set; }

        [SerializeField]
        List<Bindable> _bindings = new();

        void Awake()
        {
            _ui = GetComponent<UIDocument>().rootVisualElement;
        }

        void OnEnable()
        {

        }


        abstract class Bindable
        {
            [field: SerializeField]
            public string Name { get; private set; }
            public abstract void Bind(VisualElement ui);
        }

        [Serializable]
        class Slider : Bindable
        {
            public override void Bind(VisualElement ui)
            {
                var slider = ui.Q<UnityEngine.UIElements.Slider>(Name);
                var x =slider.dataSource;
                slider.RegisterValueChangedCallback((e) => Debug.Log(e.newValue));
            }
        }
    }
}
