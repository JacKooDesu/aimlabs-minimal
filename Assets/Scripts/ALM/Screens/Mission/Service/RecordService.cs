using VContainer;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ALM.Screens.Mission
{
    using ALM.Data;
    using Common;

    public class RecordService : IManagedFixedTickable, IManagedTickable
    {
        readonly IController _controller;
        readonly Replay _replay;

        bool _fired;

        float2 _mouseDelta;

        int _currentFrame = 0;
        float _renderTime = 0.0f;
        float _confirmedInputTime = 0.0f;

        Queue<float> _buffer = new();

        public RecordService(
            RaycasterService raycasterService,
            IController controller,
            Replay replay)
        {
            _controller = controller;
            raycasterService.OnCastBegin += caster =>
                _replay.CastFrames.TryAdd(
                    _currentFrame, new CastFrame(caster.Origin, caster.Direction));

            _replay = replay;

            // Initial frame for the first frame??
            // Note: Consider implement if replay use render tick
            // _replay.InputFrames.Add(new InputFrame(_mouseDelta = float2.zero));
            // _currentFrame++;
        }

        public void FixedTick()
        {
            _buffer.Enqueue(UnityEngine.Time.fixedDeltaTime);
            _currentFrame++;
        }

        public void Tick()
        {
            _mouseDelta += _controller.MouseDelta;
            _renderTime += UnityEngine.Time.deltaTime;
            while (_buffer.TryDequeue(out var t))
            {
                var mDelta = math.lerp(
                    0, _mouseDelta, t / (_renderTime - _confirmedInputTime));
                _confirmedInputTime += t;
                _replay.InputFrames.Add(new InputFrame(mDelta));
                _mouseDelta -= mDelta;
            }
        }
    }
}