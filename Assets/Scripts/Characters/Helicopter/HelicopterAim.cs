using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class HelicopterAim : CharacterAim
    {
        [SerializeField]
        private float _findTargetDistance = 5f;

        [SerializeField]
        private CharacterGroup _own;

        public override bool FindNearestTarget (out CharacterGroup enemy)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _findTargetDistance);

            CharacterGroup nearestEnemy = null;
            float distance = _findTargetDistance;

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out CharacterGroup enemyComponent) &&
                    _own.IsAggressive(enemyComponent))
                {
                    var distanceToEnemy = Vector3.Distance(transform.position, enemyComponent.Bounds.ClosestPoint(transform.position));
                    if (distanceToEnemy < distance)
                    {
                        distance = distanceToEnemy;
                        nearestEnemy = enemyComponent;
                    }
                }
            }
            Target = nearestEnemy;

            enemy = Target;
            return nearestEnemy != null;
        }

        public override Vector3 GetTargetPosition ()
        {
            return Target == null ? Vector3.zero : Target.Bounds.center;
        }

        public override bool IsTargetVisible ()
        {
            return Target != null && DistanceToTarget <= _findTargetDistance;
        }

#if UNITY_EDITOR
        public void OnDrawGizmos ()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _findTargetDistance);
        }
#endif
    }
}
