using VContainer;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{
    using System;
    using System.Diagnostics;
    using ALM.Common;
    using ALM.Data;
    using ALM.Screens.Base;

    public class ScoreService : IManagedTickable, IDisposable
    {
        [Inject]
        readonly MissionScoreData _data;
        [Inject]
        readonly MissionLoader.PlayableMission _mission;

        readonly RaycasterService _raycaster;

        IScoreCalculator Calculator =>
            _calculator ??= new DefaultScoreCalculator(_mission, _data);
        IScoreCalculator _calculator;

        public ScoreService(
            MissionLoader.PlayableMission mission,
            RaycasterService raycaster,
            Func<float, Timer> timerFactory)
        {
            _raycaster = raycaster;
            _raycaster.OnCastFinished += OnCasted;
        }

        void OnCasted(IRaycaster caster, IRaycastTarget target) =>
            Calculator.OnCasted(caster, target);

        public void OverrideCalculator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }

        public void Tick()
        {
            Calculator.Tick(UnityEngine.Time.deltaTime);
        }

        public void Dispose()
        {
            _raycaster.OnCastFinished -= OnCasted;
        }

        public class DefaultScoreCalculator : IScoreCalculator
        {
            public MissionScoreData Data { get; private set; }
            float _reactionTime;
            float _totalShot;
            float _totalHit;
            public readonly int _scale;
            public readonly bool _reactionTimeCal;

            public DefaultScoreCalculator(
                MissionLoader.PlayableMission mission,
                MissionScoreData data)
            {
                _scale = mission.Outline.Type switch
                {
                    MissionOutline.MissionType.Flicking => 500,
                    MissionOutline.MissionType.Tracking => 10,
                    _ => 500,
                };

                if (mission.Outline.Type == MissionOutline.MissionType.Reaction)
                    _reactionTimeCal = true;

                Data = data;
            }

            public void OnCasted(IRaycaster _, IRaycastTarget target)
            {
                if (Data?.IsManaged ?? false)
                {
                    UnityEngine.Debug.LogWarning("Cannot write to managed data");
                    return;
                }

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
            public void Tick(float deltaTime) { }

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
        }
    }

    public interface IScoreCalculator
    {
        void OnCasted(IRaycaster caster, IRaycastTarget target);
        void Tick(float deltaTime);
    }

    public class JsScoreCalculator : IScoreCalculator
    {
        public delegate void CastedAction(IRaycaster caster, IRaycastTarget target);
        // public delegate void TickAction(float t);
        CastedAction _onCasted;
        // TickAction _onTick;

        public JsScoreCalculator(
            CastedAction onCasted)
        {
            _onCasted = onCasted;
            // _onTick = onTick;
        }

        public void OnCasted(IRaycaster caster, IRaycastTarget target) =>
            _onCasted(caster, target);

        public void Tick(float deltaTime) { }
    }
}