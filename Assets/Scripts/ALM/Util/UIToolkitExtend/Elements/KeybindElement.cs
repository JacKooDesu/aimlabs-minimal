using System.Reflection;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    [UxmlElement]
    public partial class KeybindElement : BaseField<KeyCode>
    {
        Button _button;

        public KeybindElement() : base("Keybind", new Button()) => new KeybindElement("Keybind");
        public KeybindElement(string label) : base(label, new Button())
        {
            _button = this.Q<Button>();
            value = KeyCode.None;
        }
        public override KeyCode value
        {
            get => base.value;
            set
            {
                base.value = value;
                _button.text = value.ToString();
            }
        }

        public class Bindalbe : DataBinder.Bindable
        {
            protected override T ElementBuilder<T>() =>
                new KeybindElement(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<KeybindElement, KeyCode>(ui, obj, info);
        }
    }
}
