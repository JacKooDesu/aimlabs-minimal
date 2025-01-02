using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Common;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    public abstract class HandlableEntry : ITickable, IStartable, IDisposable
    {
        bool _paused = false;

        protected IEnumerable<UIBase> _uis;
        protected IEnumerable<IManagedTickable> _tickables;
        protected GameStatusHandler _handler;

        protected readonly UIDocument _rootUi;

        [Inject]
        void _Inject(
            GameStatusHandler handler,
            IEnumerable<UIBase> uis,
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

            UIStackHandler.RegisterUIs(_uis = uis);
        }

        public HandlableEntry(UIDocument rootUi)
        {
            _rootUi = rootUi;
        }

        public HandlableEntry()
        {

        }

        void IStartable.Start()
        {
            foreach (var ui in _uis)
                ui.Config(_rootUi.rootVisualElement);

            Start();
        }

        public virtual void Start() { }

        void ITickable.Tick()
        {
            this.ConstTick();

            if (_paused)
                return;

            this.Tick();

            foreach (var tickable in _tickables)
                tickable.Tick();
        }

        /// <summary>
        /// ConstTick is called every frame even entry is paused.
        /// </summary>
        protected virtual void ConstTick() { }
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