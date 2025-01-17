using System;
using Realms;

namespace ALM.Data
{
    public class ReplayData : EmbeddedObject
    {
        public int RandomSeed { get; set; }
        public byte[] ReplayBytes { get; set; }
    }
}