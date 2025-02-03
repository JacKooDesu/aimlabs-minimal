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
        FloatField _a;

        Button _colorBlock;
        public event Action<ClickEvent> OnClickColorBlock;

        public ColorBindElement() : this(false) { }
        public ColorBindElement(bool withAlpha) : base("Color", RGBContainer()) =>
            new ColorBindElement("Color", withAlpha);
        public ColorBindElement(string label, bool withAlpha = false) : base(label, RGBContainer(withAlpha))
        {
            _r = this.Q<FloatField>("R");
            _g = this.Q<FloatField>("G");
            _b = this.Q<FloatField>("B");

            if (withAlpha)
                _a = this.Q<FloatField>("A");

            _colorBlock = this.Q<Button>("ColorBlock");

            value = Color.black;
            _r.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(r: v.newValue));
            _g.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(g: v.newValue));
            _b.RegisterValueChangedCallback<float>(v =>
                value = GetColorCopy(b: v.newValue));

            if (withAlpha)
                _a.RegisterValueChangedCallback<float>(v =>
                    value = GetColorCopy(a: v.newValue));

            this.AddToClassList("color-input-field");

            _colorBlock.RegisterCallback<ClickEvent>(e => OnClickColorBlock?.Invoke(e));
        }

        protected Color GetColorCopy(float r = -1, float g = -1, float b = -1, float a = -1)
        {
            var c = value;
            if (r != -1) c.r = r;
            if (g != -1) c.g = g;
            if (b != -1) c.b = b;
            if (a != -1) c.a = a;
            return c;
        }

        protected static VisualElement RGBContainer(bool withAlpha = false)
        {
            var container = new VisualElement();
            container.style.flexDirection = FlexDirection.Row;

            container.Add(RGBField("R", 0));
            container.Add(RGBField("G", 0));
            container.Add(RGBField("B", 0));

            if (withAlpha)
                container.Add(RGBField("A", 1));

            var colorBlock = new Button();
            colorBlock.name = "ColorBlock";
            colorBlock.AddToClassList("color-input-field__color-button");
            container.Add(colorBlock);

            container.AddToClassList("color-input-field__input");
            return container;
        }

        protected static FloatField RGBField(string name, float defaultValue)
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

                (this.dataSource as IDataTarget)?.IsDirty(this.bindingPath);
            }
        }

        public class RgbBindable : UIToolkitExtend.Bindable
        {
            public Color Default;
            public Color Value
            {
                get => (Element as ColorBindElement)?.value ?? default;
                private set
                {
                    if (Element is ColorBindElement c)
                        c.value = value;
                }
            }

            public RgbBindable() { }
            public RgbBindable(Color defaultColor)
            {
                Default = defaultColor;
                AfterBuild += _ => Value = Default;
            }

            public override T ElementBuilder<T>() =>
                new ColorBindElement(Label) as T;
            public override void Bind(VisualElement ui, IDataTarget obj) =>
                CommonBind<ColorBindElement, Color>(ui, obj);
        }

        public class RgbaBindable : RgbBindable
        {
            // Rewrite constructors for js env
            public RgbaBindable() : base() { }
            public RgbaBindable(Color defaultColor) : base(defaultColor) { }
            public override T ElementBuilder<T>() =>
                new ColorBindElement(Label, true) as T;
        }
    }
}
