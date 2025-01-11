using VContainer;

namespace ALM.Screens.Mission
{
    using System;
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base;
    using Unity.Mathematics;

    public class ScoreService : IManagedTickable, IDisposable
    {
        [Inject]
        public MissionScoreData Data { get; private set; }
        readonly RaycasterService _raycaster;

        public readonly int _scale;
        public readonly bool _reactionTimeCal;

        float _reactionTime;
        float _totalShot;
        float _totalHit;

        Action<IRaycaster, IRaycastTarget> _onCasted;

        public ScoreService(
            MissionLoader.PlayableMission mission,
            RaycasterService raycaster,
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

            _raycaster = raycaster;
            raycaster.OnCastFinished += _onCasted;
            _onCasted = OnCasted;
        }

        public void OverrideCasted(Action<IRaycaster, IRaycastTarget> onCasted) =>
            _onCasted = onCasted;

        void OnCasted(IRaycaster _, IRaycastTarget target)
        {
            _totalShot += 1;

            if (target is not null)
            {
                if (_reactionTimeCal)
                {
                    Data.Score += (int)(_scale * (-math.log(_reactionTime)));
                    UpdateReactionTime();
                    _reactionTime = 0;
                }
                else
                    Data.Score += _scale;

                _totalHit += 1;
            }

            UpdateAccuracy();
        }

        void UpdateReactionTime()
        {
            Data.ReactionTime = (_reactionTime + Data.ReactionTime) * .5f;
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

        public void Dispose()
        {
            _raycaster.OnCastFinished -= _onCasted;
        }
    }
}