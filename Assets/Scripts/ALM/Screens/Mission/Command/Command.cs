using System;

namespace ALM.Screens.Mission
{
    public interface ICommand
    {
        void Execute();
        void Simulate(float t);
    }

    public partial struct Command<T> : ICommand
        where T : struct
    {
        public T Value;
        public Commander<T> Commander;
        public Func<float, T> Simulator;

        public Command(T value, Commander<T> commander, Func<float, T> simulator)
        {
            Value = value;
            Commander = commander;
            Simulator = simulator;
        }

        public void Execute() =>
            Commander.Executor(Value);

        public void Simulate(float t) =>
            Commander.Executor(Simulator?.Invoke(t) ?? Value);
    }
}