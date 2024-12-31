using System;
using System.Collections.Generic;

namespace ALM.Screens.Base
{
    public class GameStatusHandler
    {
        readonly Dictionary<Type, Action<_GameStatus>> _triggerDict;
        public _GameStatus Current { get; private set; }

        public GameStatusHandler()
        {
            _triggerDict = new();

            TriggerCreator<AsyncLoading>();
            TriggerCreator<Paused>();

            void TriggerCreator<T>() where T : _GameStatus =>
                _triggerDict.Add(typeof(T), gs => { });
        }

        public void Register<T>(Action<T> action)
            where T : _GameStatus
        {
            if (_triggerDict.TryGetValue(typeof(T), out var trigger))
                trigger += gs => action(gs as T);
            else
                throw new KeyNotFoundException($"No trigger for {typeof(T)}");
        }

        public void Set<T>(T status)
            where T : _GameStatus
        {
            Current = status;
            if (_triggerDict.TryGetValue(typeof(T), out var trigger))
                trigger?.Invoke(Current);
            else
                throw new KeyNotFoundException($"No trigger for {typeof(T)}");
        }
    }

    public abstract record _GameStatus();

    public record AsyncLoading(string Name) : _GameStatus;
    public record Paused() : _GameStatus;
}