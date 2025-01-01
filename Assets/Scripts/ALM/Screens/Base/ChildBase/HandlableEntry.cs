using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Common;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    public abstract class HandlableEntry : ITickable, IStartable, IDisposable
    {
        bool _paused = false;

        [Inject]
        protected IEnumerable<IManagedTickable> _tickables;
        [Inject]
        protected GameStatusHandler _handler;
        [Inject]
        void _Inject(
            GameStatusHandler handler,
            IEnumerable<IAutoRegister> autoRegisters,
            IEnumerable<IManagedTickable> tickables)
        {
            var type = this.GetType();
            _handler = handler;
            _tickables = tickables;
            _handler.AddEntry(type);

            _handler.Register(type, GameStatus.Paused, () => _paused = true);
            _handler.Register(type, GameStatus.Playing, () => _paused = false);

            foreach (var r in autoRegisters)
                _handler.Register(type, r.OnStatus, r.Action);
        }

        public HandlableEntry()
        {

        }

        void IStartable.Start()
        {
            Start();
        }

        public virtual void Start() { }

        void ITickable.Tick()
        {
            if (_paused)
                return;

            this.Tick();

            foreach (var tickable in _tickables)
                tickable.Tick();
        }

        protected virtual void Tick() { }

        public virtual void Dispose()
        {
            _handler.RemoveEntry(this);
        }

        interface IAutoRegister
        {
            GameStatus OnStatus { get; }
            Action Action { get; }
        }
    }
}