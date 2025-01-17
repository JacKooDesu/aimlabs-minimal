using System;

namespace ALM.Screens.Mission
{
    public class Time
    {
        public float Delta => _deltaTime();
        Func<float> _deltaTime;

        public Time(bool @fixed = false)
        {
            if (@fixed)
                _deltaTime = () => UnityEngine.Time.fixedDeltaTime;
            else
                _deltaTime = () => UnityEngine.Time.deltaTime;
        }
    }
}