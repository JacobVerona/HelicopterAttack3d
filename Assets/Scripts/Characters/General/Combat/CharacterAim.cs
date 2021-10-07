using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public abstract class CharacterAim : MonoBehaviour
    {
        public abstract float DistanceToTarget { get; }
        public abstract bool FindNearestTarget (out CharacterGroup enemy);
        public abstract Vector3 GetTargetPosition ();
        public abstract bool IsTargetVisible ();
    }
}
