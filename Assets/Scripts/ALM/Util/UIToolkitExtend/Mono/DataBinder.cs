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

        public void ManualBuild(IEnumerable<Bindable> bindables, IDataTarget obj)
        {
            _ui ??= GetComponent<UIDocument>().rootVisualElement;
            var targetUI = _ui.Q(Target);

            Bindings = new(bindables);

            foreach (var bind in Bindings)
                bind.Bind(targetUI, obj);
        }
    }

    public interface IDataTarget
    {
        event Action<string> OnChange;
        void IsDirty(string path);
    }

    public abstract class VirtaulDataTarget : IDataTarget
    {
        public event Action<string> OnChange;

        public void IsDirty(string path) => OnChange?.Invoke(path);
    }
}
