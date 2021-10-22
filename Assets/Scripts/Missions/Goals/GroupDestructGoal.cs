using HelicopterAttack.Characters;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public class GroupDestructGoal : TargetGoal
    {
        [SerializeField]
        private List<CharacterHealth> _charactersToDestruct;

        public override string Description => "missions_goal_destructgroup";

        protected virtual void OnEnable()
        {
            for (int i = 0; i < _charactersToDestruct.Count; i++)
            {
                _charactersToDestruct[i].Died += OnDied;
            }
        }

        protected virtual void OnDisable()
        {
            for (int i = 0; i < _charactersToDestruct.Count; i++)
            {
                _charactersToDestruct[i].Died -= OnDied;
            }
        }

        private void OnDied()
        {
            if (_charactersToDestruct.Where(character => character.IsDead == false).Any() == false)
            {
                Complete();
            }
        }
    }
}
