using System;

namespace ALM.Common
{
    public interface IManagedTickable
    {
        void Tick();
        public static IManagedTickable Create(Action action)
        {
            return new _T(action);
        }
        class _T : IManagedTickable
        {
            readonly Action _action;
            public _T(Action action = null) =>
                _action = action;
            public void Tick() => _action?.Invoke();
        }
    }
}