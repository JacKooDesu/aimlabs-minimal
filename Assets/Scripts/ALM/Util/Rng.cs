using System;
using Random = Unity.Mathematics.Random;

namespace ALM.Util
{
    public class Rng
    {
        public uint Seed { get; private set; }
        Random _rng;

        public Rng() =>
            new Rng((uint)System.Guid.NewGuid().GetHashCode());
        public Rng(object obj) =>
            new Rng((uint)obj.GetHashCode());
        public Rng(uint seed)
        {
            Seed = seed;
            _rng = new Random(seed);
        }

        public float Float() => _rng.NextFloat();
        public float FloatRange(float min, float max) =>
            _rng.NextFloat(min, max);
        public int IntRange(int min, int max) =>
            _rng.NextInt(min, max);

        public uint UInt() => _rng.NextUInt();
        public uint UIntRange(uint min, uint max) =>
            _rng.NextUInt(min, max);

        public Rng NewRng() => new Rng(UInt());
    }
}