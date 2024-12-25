using System;
using ALM.Common;
using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    public abstract class MenuUIBase : Common.UIBase
    {
        public event Action OnReturn;

        protected override void AfterConfig()
        {
            _elementBase.Q<Button>(className: "return-button").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PopTo(this.Index));
        }

        public virtual void SetHide(bool b)
        {
            if (b)
                _elementBase.AddToClassList("hide");
            else
                _elementBase.RemoveFromClassList("hide");
        }

        public virtual void SetActive(bool b)
        {
            if (b)
                _elementBase.RemoveFromClassList("inactive");
            else
                _elementBase.AddToClassList("inactive");
        }

        public override void Overlapped()
        {
            SetHide(true);
            SetActive(true);
        }

        public override void Return()
        {
            SetHide(false);
        }

        public override void Push()
        {
            SetHide(false);
            SetActive(true);
        }

        public override void Pop()
        {
            SetHide(false);
            SetActive(false);
        }
    }
}