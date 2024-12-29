using System;
using System.Reflection;
using UnityEngine.UIElements;
using UIElements = UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public partial class DataBinder
    {
        [Serializable]
        public class Slider : Bindable
        {
            public override T ElementBuilder<T>() =>
                new UIElements.Slider(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<UIElements.Slider, float>(ui, obj);
        }

        [Serializable]
        public class TextField : Bindable
        {
            public override T ElementBuilder<T>() =>
                new UIElements.TextField(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<UIElements.TextField, string>(ui, obj);
        }

        [Serializable]
        public class Toggle : Bindable
        {
            public override T ElementBuilder<T>() =>
                new UIElements.Toggle(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<UIElements.Toggle, bool>(ui, obj);
        }

        [Serializable]
        public class FloatField : Bindable
        {
            public override T ElementBuilder<T>() =>
                new UIElements.FloatField(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<UIElements.FloatField, float>(ui, obj);
        }

        [Serializable]
        public class IntegerField : Bindable
        {
            public override T ElementBuilder<T>() =>
                new UIElements.IntegerField(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<UIElements.IntegerField, int>(ui, obj);
        }
    }
}