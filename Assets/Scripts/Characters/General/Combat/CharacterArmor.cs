using Characters.RPG;
using HelicopterAttack.Characters.General.Combat;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterArmor : MonoBehaviour, IBulletObstacleable
    {
        [SerializeField]
        private Character _characterStats;

        public void OnHit(Bullet bullet)
        {
            _characterStats.Health.AddValue(-bullet.Damage, CharacterAttribute.ValueModifier.Base);
        }
    }
}
