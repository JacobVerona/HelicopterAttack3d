using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.Hummer
{
    public class HummerAim : CharacterAim
    {
        public float ViewRadius;

        [SerializeField]
        private CharacterGroup _group;

        private Vector3 _lastTargetPosition;

        public override bool FindNearestTarget (out CharacterGroup enemy)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, ViewRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (collider.TryGetComponent(out CharacterGroup findedEnemy))
                {
                    if (findedEnemy.gameObject != gameObject
                        && _group.IsAggressive(findedEnemy))
                    {
                        Target = findedEnemy;
                        enemy = findedEnemy;
                        return true;
                    }
                }
            }

            enemy = null;
            return false;
        }

        public override bool IsTargetVisible ()
        {
            return Target != null && DistanceToTarget < ViewRadius;
        }

        public override Vector3 GetTargetPosition ()
        {
            if (Target != null)
            {
                _lastTargetPosition = Target.Bounds.center;
            }

            return _lastTargetPosition;
        }
    }
}



