using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public abstract class CharacterAim : MonoBehaviour
    {
        [SerializeField]
        private Transform _owner;

        [SerializeField]
        protected CharacterGroup Target;

        public CharacterAim Constructor(Transform owner)
        {
            _owner = owner;
            return this;
        }

        public float DistanceToTarget
        {
            get
            {
                if (Target == null)
                {
                    return 1000000000000f;
                }

                return Vector3.Distance(transform.position, Target.Bounds.ClosestPoint(transform.position));
            }
        }

        public virtual bool IsTargetVisible()
        {
            return Target != null;
        }
        public abstract bool FindNearestTarget (out CharacterGroup enemy);
        public abstract Vector3 GetTargetPosition ();
    }
}
