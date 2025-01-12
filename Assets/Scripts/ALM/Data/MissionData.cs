using System.Linq;
using Realms;

namespace ALM.Data
{
    public class MissionData : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }
        [Backlink(nameof(PlayHistory.Mission))]
        public IQueryable<PlayHistory> PlayHistories { get; }
    }
}