using UnityEngine;

namespace HelicopterAttack.Characters.General.AI
{
    public abstract class PatrolPath
    {
        public abstract Vector3 UpdatePatrolPosition (Vector3 currentPoisition, float stoppingDistance);
    }
}



