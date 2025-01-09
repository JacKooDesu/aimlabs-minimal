using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Common;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    public abstract class HandlableEntry<TEntry> : ITickable, IStartable, IDisposable
        where TEntry : HandlableEntry<TEntry>
    {
        bool _paused = false;

        protected IEnumerable<UIBase> _uis;
        protected List<IManagedTickable> _tickables;
        protected GameStatusHandler _handler;
        protected AudioService _audioService;

        protected readonly UIDocument _rootUi;

        [Inject]
        void _Inject(
            GameStatusHandler handler,
            AudioService audioService,
            IEnumerable<UIBase> uis,
            IEnumerable<IAutoRegister> autoRegisters,
            IEnumerable<IManagedTickable> tickables)
        {
            var type = typeof(TEntry);
            _handler = handler;
            _audioService = audioService;
            _tickables = new(tickables);
            _handler.AddEntry(type);

            _handler.Register(type, GameStatus.Paused, () => _paused = true);
            _handler.Register(type, GameStatus.Playing, () => _paused = false);

            _handler.Register(type, GameStatus.Paused, () => _audioService.Pause());
            _handler.Register(type, GameStatus.Playing, () => _audioService.Resume());

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
                tickable?.Tick();
        }

        /// <summary>
        /// ConstTick is called every frame even entry is paused.
        /// </summary>
        protected virtual void ConstTick() { }
        protected virtual void Tick() { }

        void IDisposable.Dispose()
        {
            _handler.RemoveEntry(typeof(TEntry));
            this.Dispose();
        }

        public virtual void Dispose() { }

        public void RegTickable(IManagedTickable tickable) =>
            _tickables.Add(tickable);

        public void UnregTickable(IManagedTickable tickable) =>
            _tickables.Remove(tickable);

        interface IAutoRegister
        {
            GameStatus OnStatus { get; }
            Action Action { get; }
        }
    }
}