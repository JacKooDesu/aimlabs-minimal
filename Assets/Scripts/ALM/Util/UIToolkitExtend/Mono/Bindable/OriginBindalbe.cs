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
            public float Default { get; set; }
            public float Value
            {
                get => (Element as UIElements.Slider)?.value ?? default;
                set
                {
                    if (Element is UIElements.Slider s)
                        s.value = value;
                }
            }
            public float Min { get; set; }
            public float Max { get; set; }

            public Slider() { }
            public Slider(float min, float max, float defaultValue = 0)
            {
                Min = min;
                Max = max;
                Default = defaultValue;

                AfterBuild += _ => Value = Default;
            }
            public override T ElementBuilder<T>() =>
                new UIElements.Slider(Label, Min, Max) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.Slider, float>(ui, obj);
        }

        [Serializable]
        public class SliderInt : Bindable
        {
            public int Default { get; set; }
            public int Value
            {
                get => (Element as UIElements.SliderInt)?.value ?? default;
                private set
                {
                    if (Element is UIElements.SliderInt s)
                        s.value = value;
                }
            }

            public int Min { get; set; }
            public int Max { get; set; }

            public SliderInt() { }
            public SliderInt(int min, int max, int defaultValue = 0)
            {
                Min = min;
                Max = max;
                Default = defaultValue;

                AfterBuild += _ => Value = Default;
            }
            public override T ElementBuilder<T>() =>
                new UIElements.SliderInt(Label, Min, Max) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.SliderInt, int>(ui, obj);
        }

        [Serializable]
        public class TextField : Bindable
        {
            public string Default { get; set; }
            public TextField() { }
            public TextField(string defaultValue = "")
            {
                Default = defaultValue;
            }
            public string Value => (Element as UIElements.TextField)?.value;
            public override T ElementBuilder<T>() =>
                new UIElements.TextField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.TextField, string>(ui, obj);
        }

        [Serializable]
        public class Toggle : Bindable
        {
            public bool Default { get; set; }
            public bool Value
            {
                get => (Element as UIElements.Toggle)?.value ?? false;
                private set
                {
                    if (Element is UIElements.Toggle t)
                        t.value = value;
                }
            }
            public Toggle() { }
            public Toggle(bool defaultValue = false)
            {
                Default = defaultValue;
                AfterBuild += _ => Value = Default;
            }

            public override T ElementBuilder<T>() =>
                new UIElements.Toggle(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.Toggle, bool>(ui, obj);
        }

        [Serializable]
        public class FloatField : Bindable
        {
            public float Default { get; set; }
            public float Value
            {
                get => (Element as UIElements.FloatField)?.value ?? default;
                private set
                {
                    if (Element is UIElements.FloatField f)
                        f.value = value;
                }
            }
            public FloatField() { }
            public FloatField(float defaultValue = 0)
            {
                Default = defaultValue;
                AfterBuild += _ => Value = Default;
            }
            public override T ElementBuilder<T>() =>
                new UIElements.FloatField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.FloatField, float>(ui, obj);
        }

        [Serializable]
        public class IntegerField : Bindable
        {
            public int Default { get; set; }
            public int Value
            {
                get => (Element as UIElements.IntegerField)?.value ?? default;
                private set
                {
                    if (Element is UIElements.IntegerField i)
                        i.value = value;
                }
            }
            public IntegerField() { }
            public IntegerField(int defaultValue = 0)
            {
                Default = defaultValue;
                AfterBuild += _ => Value = Default;
            }
            public override T ElementBuilder<T>() =>
                new UIElements.IntegerField(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<UIElements.IntegerField, int>(ui, obj);
        }
    }
}