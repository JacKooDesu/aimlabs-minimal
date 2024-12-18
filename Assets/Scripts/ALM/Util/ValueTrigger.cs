using System;
using UnityEngine;

namespace ALM.Util
{
    [Serializable]
    public class ValueTrigger<T>
    {
        [SerializeField]
        T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                    return;
                _value = value;
                OnChange?.Invoke(_value);
            }
        }
        public event Action<T> OnChange;

        public static implicit operator T(ValueTrigger<T> self) =>
            self.Value;
        public static implicit operator ValueTrigger<T>(T value) =>
            new() { Value = value };
    }
}