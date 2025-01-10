using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public partial class DataBinder : MonoBehaviour
    {
        VisualElement _ui;

        [field: SerializeField]
        public string Target { get; private set; }

        [field: SerializeField, SerializeReference]
        public List<Bindable> Bindings { get; private set; } = new();

        void Awake()
        {
            _ui ??= GetComponent<UIDocument>().rootVisualElement;
        }

        public void ManualBuild(Bindable[] bindables, IDataTarget obj)
        {
            _ui ??= GetComponent<UIDocument>().rootVisualElement;
            var targetUI = _ui.Q(Target);

            Bindings = new(bindables);

            foreach (var bind in Bindings)
                bind.Bind(targetUI, obj);
        }

        [Serializable]
        public abstract class Bindable
        {
            [field: SerializeField]
            public string Label { get; private set; }
            [field: SerializeField]
            public string DataPath { get; private set; }

            public BindableElement Element { get; set; }

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

            protected void CommonBind<T, N>(VisualElement ui, IDataTarget obj)
                where T : BindableElement, INotifyValueChanged<N>, new()
            {
                var info = obj.GetType().GetMember(DataPath, (BindingFlags)int.MaxValue)[0];

                var element = ElementBuilder<T>();
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

    public interface IDataTarget
    {
        event Action<string> OnChange;
        void IsDirty(string path);
    }
}
