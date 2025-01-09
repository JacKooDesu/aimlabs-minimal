using System;
using UnityEngine.UIElements;

namespace ALM.Common
{
    public abstract class UIBase
    {
        protected abstract string BaseElementName { get; }
        protected VisualElement _elementBase;

        public abstract uint Index { get; }

        public UIStackHandler.UI Config(VisualElement root)
        {
            if (string.IsNullOrEmpty(BaseElementName))
                _elementBase = root;
            else
                _elementBase = root.Q(BaseElementName);


            if (_elementBase is null)
                throw new System.Exception($"{BaseElementName} not found");

            AfterConfig();

            return new(Index, this);
        }

        protected virtual void AfterConfig() { }

        public abstract void Overlapped();
        public abstract void Return();
        public abstract void Push();
        public abstract void Pop();
    }
}