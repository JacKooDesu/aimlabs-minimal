using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using ALM.Common;
    using TickGroup = Common.TickableGroup<Base.TickTiming.ConstRender>;

    public class PauseHandleService : IManagedConstTickable
    {
        const float COUNT_DOWN_TIME = 3f;

        readonly GameStatusHandler _handler;
        readonly Timer _countDownTimer;
        Action _countDownTicker;

        public event Action OnPause;
        public event Action OnResume;

        public PauseHandleService(
            GameStatusHandler handler,
            TickGroup tickGroup,
            Func<float, Timer> timerFactory)
        {
            _handler = handler;
            _countDownTimer = timerFactory(COUNT_DOWN_TIME);

            tickGroup.Reg(_countDownTimer);

            _countDownTimer.OnComplete += Resume;
        }

        void ITickable<TickTiming.ConstRender>.Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!CheckIsCountUI() &&
                    UIStackHandler.Current()?.index is not (uint)UIIndex.Base)
                    UIStackHandler.PopUI();
                else
                    Paused();
            }
        }

        void Paused()
        {
            OnPause?.Invoke();
            _countDownTimer.Pause();

            UIStackHandler.PushUI((uint)UIIndex.Pause);
            UIStackHandler.WaitUntilUiPop((uint)UIIndex.Pause)
                .ContinueWith(() => CountDown())
                .Forget();

            _handler.Set<MissionEntry>(new Set(GameStatus.Paused));
        }

        public void CountDown()
        {
            _handler.Set<MissionEntry>(new Set(GameStatus.Paused));

            if (!CheckIsCountUI())
                UIStackHandler.PushUI((uint)UIIndex.Countdown, _countDownTimer);

            _countDownTimer.Reset();
            _countDownTimer.Resume();

            // We need know when to off blur ui, 
            // not like the method Resume() to set game status
            OnResume?.Invoke();
        }

        void Resume()
        {
            if (CheckIsCountUI())
                UIStackHandler.PopUI();

            _handler.Set<MissionEntry>(new Set(GameStatus.Playing));
        }

        bool CheckIsCountUI() =>
            UIStackHandler.Current().index is (uint)UIIndex.Countdown;
    }
}
