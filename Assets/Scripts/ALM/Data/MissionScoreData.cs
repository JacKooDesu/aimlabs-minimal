using System;
using System.ComponentModel;
using Realms;
using UnityEngine;

namespace ALM.Data
{
    public class MissionScoreData : EmbeddedObject, IDisposable
    {
        public MissionScoreData()
        {
            this.PropertyChanged += OnChanged;
        }

        private void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Score))
                OnScoreChanged?.Invoke(Score);

            if (e.PropertyName == nameof(Accuracy))
                OnAccuracyChange?.Invoke(Accuracy);

            if (e.PropertyName == nameof(ReactionTime))
                OnReactionTimeChange?.Invoke(ReactionTime);
        }

        public void Dispose()
        {
            this.PropertyChanged -= OnChanged;
        }

        public int Score { get; set; }
        public float Accuracy { get; set; }
        public float ReactionTime { get; set; }

        public event Action<int> OnScoreChanged;
        public event Action<float> OnAccuracyChange;
        public event Action<float> OnReactionTimeChange;
    }
}