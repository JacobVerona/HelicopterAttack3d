using HelicopterAttack.Characters;
using System;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public class DestructGoal : GoalTarget
    {
        public override event Action<GoalTarget> Completed;

        [SerializeField]
        private CharacterHealth _targetHealth; 

        protected virtual void OnEnable()
        {
            _targetHealth.Died += OnDied;
        }

        protected virtual void OnDisable()
        {
            _targetHealth.Died -= OnDied;
        }

        private void OnDied()
        {
            Completed?.Invoke(this);
        }
    }
}
