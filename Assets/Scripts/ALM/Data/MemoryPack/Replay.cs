using System;
using System.Collections.Generic;
using UnityEngine;
using MemoryPack;
using Unity.Mathematics;
using ALM.Screens.Mission;

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

    public readonly struct InputFrame
    {
        public readonly float2 MouseDelta;

        public InputFrame(float2 mouseDelta)
        {
            MouseDelta = mouseDelta;
        }
    }

    public readonly struct CastFrame
    {
        public readonly int Caster;
        public readonly int Target;
        public readonly Vector3 Origin;
        public readonly Vector3 Direction;
        public CastFrame(
            IRaycaster raycaster, IRaycastTarget target)
        {
            Caster = raycaster.Id.Value;
            Target = target?.Id.Value ?? -1;

            Origin = raycaster.Origin;
            Direction = raycaster.Direction;
        }
    }
}