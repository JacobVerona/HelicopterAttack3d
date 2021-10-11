using HelicopterAttack.Characters.General.Combat;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    [RequireComponent(typeof(CharacterHealth))]
    public class CharacterArmor : MonoBehaviour, IBulletObstacleable
    {
        [SerializeField]
        private CharacterHealth _character;

        public virtual void OnHit(Bullet bullet)
        {
            _character.DealDamage(bullet.Damage);
        }
    }
}