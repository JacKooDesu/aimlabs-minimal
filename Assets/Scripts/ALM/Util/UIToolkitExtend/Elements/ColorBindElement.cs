using System;
using System.Reflection;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend.Elements
{
    [UxmlElement]
    public partial class ColorBindElement : BaseField<Color>
    {
        FloatField _r;
        FloatField _g;
        FloatField _b;

        Button _colorBlock;
        public event Action<ClickEvent> OnClickColorBlock;

        public ColorBindElement() : base("Color", RGBContainer()) => new ColorBindElement("Color");
        public ColorBindElement(string label) : base(label, RGBContainer())
        {
            _r = this.Q<FloatField>("R");
            _g = this.Q<FloatField>("G");
            _b = this.Q<FloatField>("B");
            _colorBlock = this.Q<Button>("ColorBlock");

            value = Color.black;
            _r.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(r: v.newValue));
            _g.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(g: v.newValue));
            _b.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(b: v.newValue));

            this.AddToClassList("color-input-field");

            _colorBlock.RegisterCallback<ClickEvent>(e => OnClickColorBlock?.Invoke(e));

            Color GetColorCopy(float r = -1, float g = -1, float b = -1)
            {
                var c = value;
                if (r != -1) c.r = r;
                if (g != -1) c.g = g;
                if (b != -1) c.b = b;
                return c;
            }
        }

        static VisualElement RGBContainer()
        {
            var container = new VisualElement();
            container.style.flexDirection = FlexDirection.Row;

            container.Add(RGBField("R", 0));
            container.Add(RGBField("G", 0));
            container.Add(RGBField("B", 0));

            var colorBlock = new Button();
            colorBlock.name = "ColorBlock";
            colorBlock.AddToClassList("color-input-field__color-button");
            container.Add(colorBlock);

            container.AddToClassList("color-input-field__input");
            return container;
        }

        static FloatField RGBField(string name, float defaultValue)
        {
            var field = new FloatField(name);
            field.name = name;
            field.AddToClassList("color-input-field__rgb-field");
            return field;
        }

        public override Color value
        {
            get => base.value;
            set
            {
                base.value = value;

                _r.value = value.r;
                _g.value = value.g;
                _b.value = value.b;

                _colorBlock.style.backgroundColor = value;
            }
        }

        public class Bindalbe : DataBinder.Bindable
        {
            public override T ElementBuilder<T>() =>
                new ColorBindElement(Label) as T;
            public override void Bind(VisualElement ui, object obj) =>
                CommonBind<ColorBindElement, Color>(ui, obj);
        }
    }
}
