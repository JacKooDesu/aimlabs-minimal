using System;
using UnityEngine;

namespace ALM.Screens.Mission
{
    public class MissionScoreData
    {
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
        }
        int _score;
        public float Accuracy
        {
            get => _acc;
            set
            {
                _acc = value;
                OnAccuracyChange?.Invoke(_acc);
            }
        }
        float _acc;

        public event Action<int> OnScoreChanged;
        public event Action<float> OnAccuracyChange;
    }
}