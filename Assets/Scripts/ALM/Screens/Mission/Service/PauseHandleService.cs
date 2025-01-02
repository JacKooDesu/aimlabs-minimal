using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using ALM.Common;

    public class PauseHandleService
    {
        const float COUNT_DOWN_TIME = 3f;

        readonly GameStatusHandler _handler;
        readonly Timer _countDownTimer;
        Action _countDownTicker;

        public PauseHandleService(
            GameStatusHandler handler,
            Func<float, Timer> timerFactory)
        {
            _handler = handler;
            _countDownTimer = timerFactory(COUNT_DOWN_TIME);

            _countDownTimer.OnComplete += Resume;
        }

        public void CheckState()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (UIStackHandler.Length() is not 0 &&
                    UIStackHandler.Current().index is not (uint)UIIndex.Countdown)
                    UIStackHandler.PopUI();
                else
                    Paused();
            }

            _countDownTicker?.Invoke();
        }

        void Paused()
        {
            _countDownTicker = null;

            UIStackHandler.PushUI((uint)UIIndex.Pause);
            UIStackHandler.WaitUntilUiPop((uint)UIIndex.Pause)
                .ContinueWith(() => CountDown())
                .Forget();

            _handler.Set<MissionEntry>(new Set(GameStatus.Paused));
        }

        public void CountDown()
        {
            _handler.Set<MissionEntry>(new Set(GameStatus.Paused));

            _countDownTimer.Reset();
            _countDownTicker = _countDownTimer.Tick;

            if (!CheckIsCountUI())
                UIStackHandler.PushUI((uint)UIIndex.Countdown, _countDownTimer);
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