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

        private CharacterGroup _target;

        public override float DistanceToTarget 
        {
            get 
            {
                if (_target == null)
                {
                    return 1000000000000f;
                }

                return Vector3.Distance(transform.position, _target.Bounds.ClosestPoint(transform.position));
            }
        }

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
                        _target = findedEnemy;
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
            return _target != null && DistanceToTarget < ViewRadius;
        }

        public override Vector3 GetTargetPosition ()
        {
            return _target == null ? Vector3.zero : _target.Bounds.center;
        }
    }
}



