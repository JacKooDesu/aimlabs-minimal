using System;
using System.Collections.Generic;
using UnityEngine;
using MemoryPack;

namespace ALM.Data
{
    [MemoryPackable]
    public partial class Replay
    {
        public uint RandomSeed { get; set; }
        public Dictionary<int, CastFrame> CastFrames { get; private set; } = new();
        public List<InputFrame> InputFrames { get; private set; } = new();

        public Replay(uint randomSeed) =>
            RandomSeed = randomSeed;

        public byte[] Serialize() =>
            MemoryPackSerializer.Serialize(this);
        public static Replay Deserialize(byte[] data) =>
            MemoryPackSerializer.Deserialize<Replay>(data);
    }

    public interface IFrame { }
    public readonly struct InputFrame
    {
        public readonly float RotX;
        public readonly float RotY;

        public InputFrame(bool fire, float rotX, float rotY)
        {
            RotX = rotX;
            RotY = rotY;
        }
    }

    public readonly struct CastFrame
    {
        public readonly Vector3 Origin;
        public readonly Vector3 Direction;
        public CastFrame(Vector3 origin, Vector3 dir)
        {
            Origin = origin;
            Direction = dir;
        }
    }
}