using System;
using System.Collections;
using System.Collections.Generic;

namespace ALM.Common
{
    public class TickableGroup<T> : ITickable
        where T : ITickable
    {
        List<T> _tickables = new();

        Queue<T> _pendingReg = new();
        Queue<T> _pendingUnreg = new();

        public void Reg(T t) =>
            _pendingReg.Enqueue(t);
        public void Unreg(T t) =>
            _pendingUnreg.Enqueue(t);

        public void Tick()
        {
            _tickables.ForEach(x => x.Tick());

            while (_pendingReg.TryDequeue(out var t))
                _tickables.Add(t);

            while (_pendingUnreg.TryDequeue(out var t))
                _tickables.Remove(t);
        }
    }
}