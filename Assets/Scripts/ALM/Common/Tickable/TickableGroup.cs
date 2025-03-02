using System;
using System.Collections;
using System.Collections.Generic;

namespace ALM.Common
{
    public class TickableGroup<T>
        where T : ITickTiming
    {
        List<ITickable<T>> _tickables = new();

        Queue<ITickable<T>> _pendingReg = new();
        Queue<ITickable<T>> _pendingUnreg = new();

        public TickableGroup() { }

        public void Reg(ITickable<T> t) =>
            _pendingReg.Enqueue(t);
        public void Unreg(ITickable<T> t) =>
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