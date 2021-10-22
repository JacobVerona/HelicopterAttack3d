using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General
{
    public class AreaAim : CharacterAim
    {
        public float ViewRadius;

        [SerializeField]
        private CharacterGroup _group;

        public override bool FindNearestTarget (out CharacterGroup enemy)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, ViewRadius);

            enemy = null;
            float distance = ViewRadius;

            for (int i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (collider.TryGetComponent(out CharacterGroup findedEnemy))
                {
                    if (findedEnemy.gameObject != gameObject
                        && _group.IsAggressive(findedEnemy))
                    {
                        var distanceToEnemy = Vector3.Distance(transform.position, findedEnemy.Bounds.ClosestPoint(transform.position));
                        
                        if (distanceToEnemy < distance)
                        {
                            distance = distanceToEnemy;

                            Target = findedEnemy;
                            enemy = findedEnemy;
                        }
                    }
                }
            }

            return enemy != null;
        }

        public override bool IsTargetVisible ()
        {
            return Target != null && DistanceToTarget < ViewRadius;
        }

        public override Vector3 GetTargetPosition ()
        {
            return IsTargetVisible() ? Target.Bounds.center : transform.position;
        }

#if UNITY_EDITOR
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ViewRadius);
        }
#endif
    }
}



