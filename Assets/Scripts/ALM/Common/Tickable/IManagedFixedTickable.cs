using System;

namespace ALM.Common
{
    public interface IManagedFixedTickable
    {
        void FixedTick();

        public static IManagedFixedTickable Create(Action action)
        {
            return new _T(action);
        }
        private class _T : IManagedFixedTickable
        {
            readonly Action _action;
            public _T(Action action = null) =>
                _action = action;
            public void FixedTick() => _action?.Invoke();
        }
    }
}