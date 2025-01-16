using System;
using System.Reflection;
using UnityEngine.UIElements;
using UnityEngine;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

namespace ALM.Util.UIToolkitExtend
{
    [Serializable]
    public abstract class Bindable
    {
        [field: SerializeField]
        public string Label { get; set; }
        [field: SerializeField]
        public string DataPath { get; set; }

        public BindableElement Element { get; set; }

        public Action<BindableElement> AfterBuild;

        public static T Create<T>(
            string label, string dataPath)
            where T : Bindable, new()
        {
            var bind = new T();
            bind.Label = label;
            bind.DataPath = dataPath;
            return bind;
        }

        public abstract void Bind(VisualElement ui, IDataTarget obj);

        public virtual T ElementBuilder<T>()
            where T : BindableElement, new() =>
            new T();

        protected virtual void CommonBind<T, N>(VisualElement ui, IDataTarget obj)
            where T : BindableElement, INotifyValueChanged<N>, new()
        {
            if (obj is VirtaulDataTarget vObj)
            {
                VirtualBind<T, N>(ui, vObj);
                return;
            }

            var info = obj.GetType().GetMember(DataPath, (BindingFlags)int.MaxValue)[0];

            var element = ElementBuilder<T>();
            AfterBuild?.Invoke(element);
            this.Element = element;

            ui.Add(element);
            element.value = info switch
            {
                FieldInfo field => (N)field.GetValue(obj),
                PropertyInfo property => (N)property.GetValue(obj),
                _ => throw new NotImplementedException()
            };
            element.dataSource = obj;
            element.dataSourceType = obj.GetType();
            element.bindingPath = info.Name;
            element.RegisterValueChangedCallback<N>(CommonCallback<N>(obj, info));
        }

        void VirtualBind<T, N>(VisualElement ui, VirtaulDataTarget obj)
            where T : BindableElement, INotifyValueChanged<N>, new()
        {
            var element = ElementBuilder<T>();
            AfterBuild?.Invoke(element);
            this.Element = element;
            ui.Add(element);
            element.RegisterValueChangedCallback<N>(_ => obj.IsDirty(DataPath));
        }

        protected EventCallback<ChangeEvent<T>> CommonCallback<T>(IDataTarget obj, MemberInfo info) =>
            value =>
            {
                Action<IDataTarget, object> action = info switch
                {
                    FieldInfo field => field.SetValue,
                    PropertyInfo property => property.SetValue,
                    MethodInfo method => (o, v) => method.Invoke(o, new[] { v }),
                    _ => throw new NotImplementedException()
                };

                action(obj, value.newValue);
                obj.IsDirty(info.Name);
            };
    }

    [Serializable]
    public class DirectBindable<B, BElement, BType> : Bindable
        where B : Bindable, new()
        where BElement : BindableElement, INotifyValueChanged<BType>, new()
    {
        public override void Bind(VisualElement ui, IDataTarget obj)
        {
            var bindable = Create<B>(Label, DataPath);
            var element = bindable.ElementBuilder<BElement>();
            ui.Add(element);

            element.dataSource = obj;
            element.dataSourceType = obj.GetType();
            element.bindingPath = DataPath;

            this.Element = element;
        }
    }
}