using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ALM.Util.EventBinder
{
    public abstract class CollideEventHandler : CollideBasedHandler
    {
        public enum Timing
        {
            Enter,
            Stay,
            Exit
        }

        public abstract class Setting
        {
            public abstract void Invoke<T>(T component) where T : Component;
        }
        public class Setting<T> : Setting
        where T : Component
        {
            internal UnityEvent<T> Event { get; } = new();
            public override void Invoke<_>(_ t) => Event.Invoke(t as T);
        }

        protected Dictionary<Timing, Dictionary<Type, Setting>> hooks { get; set; } = new();

        protected C Register<C, T>(
            C handler,
            Timing timing,
            UnityAction<T> action)
        where C : CollideEventHandler
        where T : Component
        {
            Dictionary<Type, Setting> dict;
            if (!handler.hooks.TryGetValue(timing, out dict))
                handler.hooks.Add(timing, dict = new());

            var component = typeof(T);
            Setting<T> target;
            if (dict.ContainsKey(component))
                target = dict[component] as Setting<T>;
            else
            {
                target = new();
                dict.Add(component, target as Setting);
            }

            target.Event.AddListener(action);
            return handler;
        }
        protected delegate bool CheckerDel(Type type, out Component component);
        protected void Check(Timing timing, CheckerDel checker)
        {
            if (!hooks.TryGetValue(timing, out var dict))
                return;
            foreach (var (type, setting) in dict)
            {
                if (checker(type, out var component))
                    setting.Invoke(component);
            }
        }
    }
}