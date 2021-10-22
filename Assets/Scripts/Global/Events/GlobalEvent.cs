using System;
using UnityEngine;

namespace HelicopterAttack.Global
{
    public class GlobalEvent<T> : GlobalEvent
    {
        [SerializeField]
        private event Action<T> _event;

        public void AddListener(Action<T> listener)
        {
            _event += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            _event -= listener;
        }

        public void Invoke(T data)
        {
            _event?.Invoke(data);
        }
    }

    public abstract class GlobalEvent : ScriptableObject { }
}
