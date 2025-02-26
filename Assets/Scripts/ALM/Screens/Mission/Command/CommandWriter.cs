using System;
using System.Collections;
using System.Collections.Generic;
using ALM.Common;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{
    public class CommandWriter : IManagedTickable, IManagedFixedTickable
    {
        Queue<ICommand> _commands = new Queue<ICommand>();

        float _renderTime = 0f;

        public void Write<T>(Commander<T> commander, T value, Func<float, T> simulator)
            where T : struct
        {
            _commands.Enqueue(new Command<T>
            {
                Value = value,
                Commander = commander,
                Simulator = simulator
            });
        }

        public void Write(ICommand cmd) =>
            _commands.Enqueue(cmd);

        public void FixedTick()
        {
            _renderTime = 0;

            while (_commands.TryDequeue(out var command))
                command.Execute();
        }

        public void Tick()
        {
            _renderTime += UnityEngine.Time.deltaTime;
            var t = _renderTime / UnityEngine.Time.fixedDeltaTime;
            t.Dbg();
            foreach (var command in _commands)
                command.Simulate(t);
        }
    }
}