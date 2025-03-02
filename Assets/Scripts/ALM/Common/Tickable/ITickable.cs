using System;

namespace ALM.Common
{
    public interface ITickTiming { }
    public interface ITickable<T>
        where T : ITickTiming
    {
        void Tick();

        public static ITickable<T> Create(Action action)
        {
            return new _T(action);
        }
        class _T : ITickable<T>
        {
            readonly Action _action;
            public _T(Action action = null) =>
                _action = action;
            public void Tick() => _action?.Invoke();
        }
    }
}