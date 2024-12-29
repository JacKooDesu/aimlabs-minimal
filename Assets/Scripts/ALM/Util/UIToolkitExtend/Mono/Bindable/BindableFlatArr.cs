using System;
using System.Reflection;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    using Bindable = DataBinder.Bindable;

    /// <summary>
    /// This is a bindable for binding array of data
    /// </summary>
    /// <typeparam name="B">Bindable Type</typeparam>
    /// <typeparam name="BElement">Bindable Element</typeparam>
    /// <typeparam name="BType">Bind Value Type</typeparam>
    [Serializable]
    public class BindableFlatArr<B, BElement, BType> : Bindable
        where B : Bindable, new()
        where BElement : BindableElement, INotifyValueChanged<BType>, new()
    {
        public override void Bind(VisualElement ui, object obj, MemberInfo info)
        {
            var arrObj = info switch
            {
                FieldInfo field => field.GetValue(obj),
                PropertyInfo property => property.GetValue(obj),
                _ => throw new NotImplementedException()
            };

            if (arrObj is not Array arr)
                throw new ArgumentException("The target object is not an array.");

            for (int i = 0; i < arr.Length; ++i)
            {
                var index = i;

                var bindable = Bindable.Create<B>(Label + ' ' + index, DataPath + $".Array.data[{i}]");
                var element = bindable.ElementBuilder<BElement>();

                ui.Add(element);
                element.value = (BType)arr.GetValue(index);
                element.dataSource = DataPath + $".Array.data[{index}]";
                element.bindingPath = info.Name;
                element.RegisterValueChangedCallback<BType>(v => arr.SetValue(v.newValue, index));
            }
        }
    }
}
