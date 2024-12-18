using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using UIElements = UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public class DataBinder : MonoBehaviour
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

        public void ManualBuild(Bindable[] bindables, object obj)
        {
            _ui ??= GetComponent<UIDocument>().rootVisualElement;

            Bindings = new(bindables);

            foreach (var bind in Bindings)
                bind.Bind(_ui.Q(Target), obj, obj.GetType().GetMember(bind.DataPath)[0]);
        }

        [Serializable]
        public abstract class Bindable
        {
            [field: SerializeField]
            public string Label { get; private set; }
            [field: SerializeField]
            public string DataPath { get; private set; }

            public BindableElement Element { get; private set; }

            public static T Create<T>(
                string label, string dataPath)
                where T : Bindable, new()
            {
                var bind = new T();
                bind.Label = label;
                bind.DataPath = dataPath;
                return bind;
            }

            public abstract void Bind(VisualElement ui, object obj, MemberInfo info);

            protected virtual T ElementBuilder<T>()
                where T : BindableElement, new() =>
                new T();

            protected void CommonBind<T, N>(VisualElement ui, object obj, MemberInfo info)
                where T : BindableElement, INotifyValueChanged<N>, new()
            {
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
            protected EventCallback<ChangeEvent<T>> CommonCallback<T>(object obj, MemberInfo info) =>
                value =>
                {
                    Action<object, object> action = info switch
                    {
                        FieldInfo field => field.SetValue,
                        PropertyInfo property => property.SetValue,
                        _ => throw new NotImplementedException()
                    };

                    action(obj, value.newValue);
                };
        }

        [Serializable]
        public class Slider : Bindable
        {
            protected override T ElementBuilder<T>() =>
                new UIElements.Slider(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<UIElements.Slider, float>(ui, obj, info);
        }

        [Serializable]
        public class TextField : Bindable
        {
            protected override T ElementBuilder<T>() =>
                new UIElements.TextField(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<UIElements.TextField, string>(ui, obj, info);
        }

        [Serializable]
        public class Toggle : Bindable
        {
            protected override T ElementBuilder<T>() =>
                new UIElements.Toggle(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<UIElements.Toggle, bool>(ui, obj, info);
        }

        [Serializable]
        public class FloatField : Bindable
        {
            protected override T ElementBuilder<T>() =>
                new UIElements.FloatField(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<UIElements.FloatField, float>(ui, obj, info);
        }

        [Serializable]
        public class IntegerField : Bindable
        {
            protected override T ElementBuilder<T>() =>
                new UIElements.IntegerField(Label) as T;
            public override void Bind(VisualElement ui, object obj, MemberInfo info) =>
                CommonBind<UIElements.IntegerField, int>(ui, obj, info);
        }
    }
}
