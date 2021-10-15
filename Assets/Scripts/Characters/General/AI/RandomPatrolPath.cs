using UnityEngine;

namespace HelicopterAttack.Characters.General.AI
{
    public class RandomPatrolPath : IPatrolPath
    {
        private Vector3 _prevPosition;
        private Vector3 _nextPosition;

        public RandomPatrolPath (Vector3 centerPoint, float patrolRadius)
        {
            _prevPosition = centerPoint;

            PatrolCenterPosition = centerPoint;
            PatrolRadius = patrolRadius;

            UpdatePatrolPosition(centerPoint, 10000000f);
        }

        public Vector3 PatrolCenterPosition { get; set; }
        public float PatrolRadius { get; set; }

        public Vector3 UpdatePatrolPosition (Vector3 currentPosition, float stoppingDistance)
        {
            if (Vector3.Distance(_prevPosition, currentPosition) < stoppingDistance)
            {
                var randomOffset = new Vector3(Random.Range(-PatrolRadius, PatrolRadius), PatrolCenterPosition.y, Random.Range(-PatrolRadius, PatrolRadius));
                _nextPosition = PatrolCenterPosition + randomOffset;
            }

            _prevPosition = currentPosition;
            return _nextPosition;
        }
    }
}



