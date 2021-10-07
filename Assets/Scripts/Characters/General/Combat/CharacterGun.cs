using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public abstract class CharacterGun : MonoBehaviour
    {
        public abstract void TryShoot (Vector3 position);
    }
}
