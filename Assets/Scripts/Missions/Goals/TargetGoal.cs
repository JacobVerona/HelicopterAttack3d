using System;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public abstract class TargetGoal : MonoBehaviour
    {
        public event Action<TargetGoal> Completed;

        public bool IsCompleted { get; private set; }
        public abstract string Description { get; }

        protected void Complete()
        {
            IsCompleted = true;
            Completed?.Invoke(this);
        }
    }
}
