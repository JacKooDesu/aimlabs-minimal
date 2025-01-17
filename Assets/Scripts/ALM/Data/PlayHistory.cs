using System;
using Realms;

namespace ALM.Data
{
    public class PlayHistory : RealmObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public MissionData Mission { get; set; }
        public DateTimeOffset PlayedAt { get; set; }
        public MissionScoreData ScoreData { get; set; }
        public byte[] ReplayData { get; set; }

        public PlayHistory() { }

        public PlayHistory(
            MissionData mission,
            MissionScoreData scoreData)
        {
            Id = Guid.NewGuid();
            Mission = mission;
            PlayedAt = DateTimeOffset.Now;
            ScoreData = scoreData;
        }
    }
}