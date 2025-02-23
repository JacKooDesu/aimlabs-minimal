using System;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{
    using ALM.Common;
    using ALM.Data;

    public class ReplayPlayerService : IManagedFixedTickable
    {
        readonly Replay _replay;
        readonly RaycasterService _raycasterService;
        readonly EntityService _entityService;

        readonly InputFrame[] _inputFrames;

        public InputFrame CurrentInput => _inputFrames[_currentFrame];

        int _currentFrame = 0;
        public int CurrentFrame => _currentFrame;
        float _fixedTime = 0.0f;
        public float FixedTime => _fixedTime;

        public event Action<InputFrame> OnUpdateInput;

        public ReplayPlayerService(
            Replay replay,
            RaycasterService raycasterService,
            EntityService entityService)
        {
            _replay = replay;
            _raycasterService = raycasterService;
            _entityService = entityService;

            _inputFrames = _replay.InputFrames.ToArray();
        }

        public void FixedTick()
        {
            _fixedTime += UnityEngine.Time.fixedDeltaTime;

            if (_currentFrame >= _replay.InputFrames.Count)
                return;

            if (_replay.CastFrames.TryGetValue(_currentFrame, out var cf))
            {
                IRaycaster caster;
                IRaycastTarget target;
                if (_entityService.TryGet(cf.Caster, out caster) &&
                    _entityService.TryGet(cf.Target, out target))
                    _raycasterService.CastOverride(caster, target);
            }

            var frame = _replay.InputFrames[_currentFrame];
            OnUpdateInput?.Invoke(frame);

            _currentFrame++;
        }

        public Span<InputFrame> GetInputSpan(int range = 0)
        {
            var end = math.clamp(_currentFrame + range, 0, _inputFrames.Length - 1);

            if (end == _currentFrame)
                return Span<InputFrame>.Empty;

            return _inputFrames.AsSpan(_currentFrame..(_currentFrame + range));
        }
    }
}