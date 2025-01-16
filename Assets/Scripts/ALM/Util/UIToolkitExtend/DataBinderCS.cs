using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend
{
    public class DataBinderCS
    {
        Dictionary<string, Bindable> _bindables { get; } = new();
        readonly VisualElement _ui;

        public DataBinderCS(
            VisualElement ui, Bindable[] bindables, IDataTarget obj)
        {
            _ui = ui;
            foreach (var bind in bindables)
            {
                bind.Bind(_ui, obj);
                _bindables.Add(bind.DataPath, bind);
            }
        }
    }
}