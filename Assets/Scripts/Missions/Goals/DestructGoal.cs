using HelicopterAttack.Characters;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public class DestructGoal : TargetGoal
    {
        [SerializeField]
        private CharacterHealth _targetHealth;

        public override string Description => "missions_goal_destruct";

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
            Complete();
        }
    }
}
