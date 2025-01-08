using VContainer;

namespace ALM.Screens.Mission
{
    using System;
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base;
    using Unity.Mathematics;

    public class ScoreService : IManagedTickable
    {
        [Inject]
        public MissionScoreData Data { get; private set; }

        readonly int _scale;
        readonly bool _reactionTimeCal;

        float _reactionTime;
        float _totalShot;
        float _totalHit;

        public ScoreService(
            MissionLoader.PlayableMission mission,
            RaycasterService raycasterService,
            Func<float, Timer> timerFactory)
        {
            _scale = mission.Outline.Type switch
            {
                MissionOutline.MissionType.Flicking => 500,
                MissionOutline.MissionType.Tracking => 10,
                _ => 500,
            };

            if (mission.Outline.Type == MissionOutline.MissionType.Reaction)
                _reactionTimeCal = true;

            raycasterService.OnCastFinished += OnCasted;
        }

        void OnCasted(IRaycastTarget target)
        {
            _totalShot += 1;

            if (target is not null)
            {
                if (_reactionTimeCal)
                {
                    Data.Score += (int)(_scale * (-math.log(_reactionTime)));
                    _reactionTime = 0;
                }
                else
                    Data.Score += _scale;

                _totalHit += 1;
            }

            UpdateAccuracy();
        }

        void UpdateAccuracy()
        {
            if (_totalShot == 0)
                return;

            Data.Accuracy = _totalHit / _totalShot;
        }

        public void Tick()
        {
            if (!_reactionTimeCal)
                return;

            _reactionTime += UnityEngine.Time.deltaTime;
        }
    }
}