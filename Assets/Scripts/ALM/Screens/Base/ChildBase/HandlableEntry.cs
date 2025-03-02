using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Common;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using ConstTickGroup = Common.TickableGroup<TickTiming.ConstRender>;
    using ConstFixedTickGroup = Common.TickableGroup<TickTiming.ConstFixed>;
    using TickGroup = Common.TickableGroup<TickTiming.ManagedRender>;
    using FixedGroup = Common.TickableGroup<TickTiming.ManagedFixed>;

    public abstract class HandlableEntry<TEntry> : ITickable, IFixedTickable, IStartable, IDisposable
        where TEntry : HandlableEntry<TEntry>
    {
        bool _paused = false;

        protected IEnumerable<UIBase> _uis;
        ConstTickGroup _constTickGroup;
        ConstFixedTickGroup _constFixedTickGroup;
        TickGroup _tickGroup;
        FixedGroup _fixedGroup;
        protected List<IManagedFixedTickable> _fixedTickables;
        protected GameStatusHandler _handler;
        protected AudioService _audioService;
        protected readonly UIDocument _rootUi;

        [Inject]
        void _Inject(
            GameStatusHandler handler,
            AudioService audioService,
            IEnumerable<UIBase> uis,
            IEnumerable<IManagedTickable> tickables,
            IEnumerable<IManagedFixedTickable> fixedTickables,
            IEnumerable<IManagedConstTickable> constTickables,
            IEnumerable<IManagedConstFixedTickable> constFixedTickables,
            ConstTickGroup constTickGroup,
            ConstFixedTickGroup constFixedTickGroup,
            TickGroup tickGroup,
            FixedGroup fixedGroup,
            IEnumerable<IAutoRegister> autoRegisters)
        {
            var type = typeof(TEntry);
            _handler = handler;
            _audioService = audioService;

            _constTickGroup = constTickGroup;
            _constFixedTickGroup = constFixedTickGroup;
            _tickGroup = tickGroup;
            _fixedGroup = fixedGroup;

            foreach (var t in tickables)
                _tickGroup.Reg(t);

            foreach (var t in fixedTickables)
                _fixedGroup.Reg(t);

            foreach (var t in constTickables)
                _constTickGroup.Reg(t);

            foreach (var t in constFixedTickables)
                _constFixedTickGroup.Reg(t);

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
            _tickGroup.Tick();
            _fixedGroup.Tick();
            _constTickGroup.Tick();
            _constFixedTickGroup.Tick();

            foreach (var ui in _uis)
                ui.Config(_rootUi.rootVisualElement);

            Start();
        }

        public virtual void Start() { }

        void ITickable.Tick()
        {
            this.ConstTick();

            _constTickGroup.Tick();

            if (_paused)
                return;

            this.Tick();
            _tickGroup.Tick();
        }

        void IFixedTickable.FixedTick()
        {
            ConstFixedTick();
            _constFixedTickGroup.Tick();

            if (_paused)
                return;

            FixedTick();
            _fixedGroup.Tick();
        }

        /// <summary>
        /// ConstTick is called every frame even entry is paused.
        /// </summary>
        protected virtual void ConstTick() { }
        protected virtual void Tick() { }

        protected virtual void ConstFixedTick() { }
        protected virtual void FixedTick() { }

        void IDisposable.Dispose()
        {
            _handler.RemoveEntry(typeof(TEntry));
            this.Dispose();
        }

        public virtual void Dispose() { }

        interface IAutoRegister
        {
            GameStatus OnStatus { get; }
            Action Action { get; }
        }
    }
}