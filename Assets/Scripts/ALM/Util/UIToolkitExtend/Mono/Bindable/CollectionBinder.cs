using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    using Bindable = DataBinder.Bindable;

    public class AbstractBindable : Bindable
    {
        public delegate void __BindDel(Bindable b, VisualElement ui, object obj);
        __BindDel _binder;
        public AbstractBindable(__BindDel binder) =>
            this._binder = binder;
        public override void Bind(VisualElement ui, object obj) =>
            _binder?.Invoke(this, ui, obj);
    }

    public static class CollectionBinder
    {
        public static Bindable[] Array<TParent, B, BElement, BType>(TParent parent, string baseLabel, string memberName)
            where B : Bindable, new()
            where BElement : BindableElement, INotifyValueChanged<BType>, new()
        {
            var arrObj = typeof(TParent)
                .GetMember(memberName, (BindingFlags)int.MaxValue)[0] switch
            {
                FieldInfo field => field.GetValue(parent),
                PropertyInfo property => property.GetValue(parent),
                _ => throw new NotImplementedException()
            } is not Array arr
                    ? throw new ArgumentException("The target object is not an array.")
                    : arr;

            return (arr as BType[]).Select((v, i) =>
                new AbstractBindable((b, ui, obj) =>
                {
                    var index = i;

                    var bindable = Bindable.Create<B>(baseLabel + ' ' + index, memberName + $".Array.data[{i}]");
                    var element = bindable.ElementBuilder<BElement>();

                    b.Element = element;

                    element.value = (BType)arr.GetValue(index);
                    element.dataSource = parent;
                    element.dataSourceType = typeof(TParent);
                    element.bindingPath = memberName + $".Array.data[{index}]";

                    element.RegisterValueChangedCallback<BType>(v => arr.SetValue(v.newValue, index));

                    ui.Add(element);
                })).ToArray();
        }

        public static Bindable[] Dictionary<TParent, B, BElement, BType>(TParent parent, string baseLabel, string memberName)
            where B : Bindable, new()
            where BElement : BindableElement, INotifyValueChanged<BType>, new()
        {
            var dictObj = typeof(TParent)
                .GetMember(memberName, (BindingFlags)int.MaxValue)[0] switch
            {
                FieldInfo field => field.GetValue(parent),
                PropertyInfo property => property.GetValue(parent),
                _ => throw new NotImplementedException()
            } is not IDictionary dict
                    ? throw new ArgumentException("The target object is not a dictionary.")
                    : dict;

            return dict.Keys.Cast<object>().Select((k, i) =>
                new AbstractBindable((b, ui, obj) =>
                {
                    var key = k;

                    var bindable = Bindable.Create<B>(baseLabel + ' ' + key, memberName + $".Dictionary.data[{key}]");
                    var element = bindable.ElementBuilder<BElement>();

                    b.Element = element;

                    element.value = (BType)dict[key];
                    element.dataSource = parent;
                    element.dataSourceType = typeof(TParent);
                    element.bindingPath = memberName + $".Dictionary.data[{key}]";

                    element.RegisterValueChangedCallback<BType>(v => dict[key] = v.newValue);

                    ui.Add(element);
                })).ToArray();
        }
    }
}
