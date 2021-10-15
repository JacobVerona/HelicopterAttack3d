using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public abstract class CharacterAim : MonoBehaviour
    {
        [SerializeField]
        protected CharacterGroup Target;

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

        public abstract bool FindNearestTarget (out CharacterGroup enemy);
        public abstract Vector3 GetTargetPosition ();
        public abstract bool IsTargetVisible ();
    }
}
