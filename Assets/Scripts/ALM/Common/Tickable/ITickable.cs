using System;

namespace ALM.Common
{
    public interface ITickable
    {
        void Tick();
        public interface ITiming
        {
            // public int Identifier;
        }

        public static ITickable Create(Action action)
        {
            return new _T(action);
        }
        class _T : ITickable
        {
            readonly Action _action;
            public _T(Action action = null) =>
                _action = action;
            public void Tick() => _action?.Invoke();
        }
    }

    public interface ITickable<T> : ITickable
        where T : ITickable.ITiming
    {
        public static new ITickable<T> Create(Action action)
        {
            return new _TT(action);
        }
        class _TT : ITickable<T>
        {
            readonly Action _action;
            public _TT(Action action = null) =>
                _action = action;
            public void Tick() => _action?.Invoke();
        }
    }
}