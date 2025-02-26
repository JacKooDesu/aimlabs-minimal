using Unity.Mathematics;
using V3 = UnityEngine.Vector3;

namespace ALM.Screens.Mission
{
    public partial struct Command<T> : ICommand { }

    public struct Vector3Command : ICommand
    {
        public V3 Value;
        public Commander<V3> Commander;

        public Vector3Command(V3 value, Commander<V3> commander)
        {
            Value = value;
            Commander = commander;
        }

        public void Execute() =>
            Commander.Executor(Value);

        public void Simulate(float t) =>
            Commander.Executor(math.lerp(V3.zero, Value, t));
    }
}