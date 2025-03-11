using VContainer;

namespace ALM.Screens.Mission
{
    using ALM.Data;
    using ALM.Screens.Base;
    using Common;

    public class RecordService : IManagedFixedTickable
    {
        readonly IController _controller;
        [Inject]
        readonly Replay _replay;

        bool _fired;

        int _currentFrame = 0;

        public RecordService(
            RaycasterService raycasterService,
            IController controller)
        {
            _controller = controller;
            raycasterService.OnCastBegin += caster =>
                _replay.CastFrames.TryAdd(
                    _currentFrame, new CastFrame(caster.Origin, caster.Direction));
        }

        public void RecordMethodCall(System.Type serviceType, string methodName, params string[] parameters)
        {
        }

        void ITickable<TickTiming.ManagedFixed>.Tick()
        {
            var rotX = _controller.RotX;
            var rotY = _controller.RotY;
            _replay.InputFrames.Add(new InputFrame(_fired, rotX, rotY));
            _fired = false;
            _currentFrame++;
        }
    }
}