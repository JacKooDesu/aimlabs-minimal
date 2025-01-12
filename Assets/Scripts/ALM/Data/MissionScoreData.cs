using System;
using Realms;
using UnityEngine;

namespace ALM.Data
{
    public class MissionScoreData : RealmObject
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
        int _score { get; set; }
        public float Accuracy
        {
            get => _acc;
            set
            {
                _acc = value;
                OnAccuracyChange?.Invoke(_acc);
            }
        }
        float _acc { get; set; }

        public float ReactionTime
        {
            get => _reactionTime;
            set
            {
                _reactionTime = value;
                OnReactionTimeChange?.Invoke(_reactionTime);
            }
        }
        float _reactionTime { get; set; }

        public event Action<int> OnScoreChanged;
        public event Action<float> OnAccuracyChange;
        public event Action<float> OnReactionTimeChange;
    }
}