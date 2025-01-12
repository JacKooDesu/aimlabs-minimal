using System;
using System.Linq;
using ALM.Data;
using ALM.Screens.Mission;
using ALM.Util;
using Newtonsoft.Json;
using Realms;
using VContainer;

namespace ALM.Screens.Base.Service
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

        public void Dispose() { }
    }
}