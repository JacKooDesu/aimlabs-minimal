using System;
using System.Reflection;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine.UIElements;
using UIElements = UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public class OriginBindalbe
    {
        [Serializable]
        public class Slider : Bindable
        {
            public float Value =>
                (Element as UIElements.Slider)?.value ?? default;
            public float Min { get; set; }
            public float Max { get; set; }
            public override T ElementBuilder<T>() =>
                new UIElements.Slider(Label, Min, Max) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.Slider, float>(ui, obj);
        }

        [Serializable]
        public class SliderInt : Bindable
        {
            public int Value =>
                (Element as UIElements.SliderInt)?.value ?? default;
            public int Min { get; set; }
            public int Max { get; set; }

            public SliderInt(int min, int max)
            {
                Min = min;
                Max = max;
            }
            public override T ElementBuilder<T>() =>
                new UIElements.SliderInt(Label, Min, Max) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.SliderInt, int>(ui, obj);
        }

        [Serializable]
        public class TextField : Bindable
        {
            public string Value => (Element as UIElements.TextField)?.value;
            public override T ElementBuilder<T>() =>
                new UIElements.TextField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.TextField, string>(ui, obj);
        }

        [Serializable]
        public class Toggle : Bindable
        {
            public bool Value => (Element as UIElements.Toggle)?.value ?? false;
            public override T ElementBuilder<T>() =>
                new UIElements.Toggle(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.Toggle, bool>(ui, obj);
        }

        [Serializable]
        public class FloatField : Bindable
        {
            public float Value => (Element as UIElements.FloatField)?.value ?? default;
            public override T ElementBuilder<T>() =>
                new UIElements.FloatField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.FloatField, float>(ui, obj);
        }

        [Serializable]
        public class IntegerField : Bindable
        {
            public int Value => (Element as UIElements.IntegerField)?.value ?? default;
            public override T ElementBuilder<T>() =>
                new UIElements.IntegerField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.IntegerField, int>(ui, obj);
        }
    }
}