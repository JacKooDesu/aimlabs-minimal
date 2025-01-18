using System;
using System.Collections.Generic;
using System.Linq;

namespace ALM.Screens.Base
{
    public class GameStatusHandler
    {
        readonly Dictionary<Type, (uint priority, GameStatus status)> _statusDict;
        readonly Dictionary<Type, Dictionary<GameStatus, List<Action>>> _triggerDict;

        public GameStatusHandler()
        {
            _statusDict = new();
            _triggerDict = new();
        }

        public void AddEntry<T>(T entry)
            where T : HandlableEntry<T> =>
            AddEntry(typeof(T));
        public void AddEntry(Type type)
        {
            _statusDict.TryAdd(type, (0, GameStatus.Playing));
            _triggerDict.TryAdd(type, new());
        }

        public void RemoveEntry<T>(T entry)
            where T : HandlableEntry<T> =>
            RemoveEntry(typeof(T));
        public void RemoveEntry(Type type)
        {
            _statusDict.Remove(type);
            _triggerDict.Remove(type);
        }

        public void Register<T>(GameStatus status, Action action) =>
            Register(typeof(T), status, action);
        public void Register<T>(T _, GameStatus status, Action action)
            where T : HandlableEntry<T> =>
            Register(typeof(T), status, action);
        public void Register(Type type, GameStatus status, Action action)
        {
            if (!_triggerDict.TryGetValue(type, out var dict))
                throw new InvalidOperationException("Entry not found");

            if (!dict.TryGetValue(status, out var triggers))
                dict.Add(status, triggers = new());

            triggers.Add(action);
        }

        public void GlobalSet(GameStatusSetter setter)
        {
            for (int i = 0; i < _statusDict.Count; i++)
            {
                var type = _statusDict.Keys.ElementAt(i);
                Set(type, setter);
            }
        }

        public void Set<T>(GameStatusSetter setter)
            where T : HandlableEntry<T> =>
            Set(typeof(T), setter);

        public void Set(Type type, GameStatusSetter setter)
        {
            if (!_statusDict.ContainsKey(type))
                throw new InvalidOperationException("Entry not found");

            var oldStatus = _statusDict[type];
            var newStatus = setter switch
            {
                Force force => (0u, force.Status),
                Set set => oldStatus.priority > set.Priority ? oldStatus : (set.Priority, set.Status),
                _ => throw new InvalidOperationException("Invalid setter")
            };

            if (oldStatus.status != newStatus.Item2)
                Trigger(type, newStatus.Item2);

            _statusDict[type] = newStatus;
        }

        void Trigger(Type type, GameStatus status)
        {
            if (!_triggerDict.TryGetValue(type, out var dict) ||
                !dict.TryGetValue(status, out var triggers))
                return;

            triggers.ForEach(t => t());
        }
    }

    public enum GameStatus : uint
    {
        Playing,
        Paused
    }

    public abstract record GameStatusSetter();
    public record Force(GameStatus Status) : GameStatusSetter;
    // public record Resume() : GameStatusSetter;
    public record Set(GameStatus Status, uint Priority = 0) : GameStatusSetter;
}