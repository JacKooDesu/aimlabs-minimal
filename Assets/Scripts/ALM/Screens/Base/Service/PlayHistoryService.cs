using System;
using System.Linq;
using ALM.Data;
using ALM.Screens.Mission;
using ALM.Util;
using Newtonsoft.Json;
using Realms;
using VContainer;

namespace ALM.Screens.Base
{
    public class PlayHistoryService : IDisposable
    {
        [Inject]
        readonly Realm _realm;

        public void AddPlayHistory(
            MissionData mission,
            MissionScoreData scoreData) =>
            _realm.Write(() => _realm.Add(new PlayHistory(mission, scoreData)));

        public void AddPlayHistory(PlayHistory history) =>
            _realm.Write(() => _realm.Add(history));

        public IQueryable<PlayHistory> GetPlayHistories(string mission) =>
            _realm.Find<MissionData>(mission).PlayHistories;

        public void Dispose() { }
    }
}