using UnityEngine;

namespace HelicopterAttack.Characters.General.AI
{
    public interface IPatrolPath
    {
        Vector3 UpdatePatrolPosition (Vector3 currentPoisition, float stoppingDistance);
    }
}



