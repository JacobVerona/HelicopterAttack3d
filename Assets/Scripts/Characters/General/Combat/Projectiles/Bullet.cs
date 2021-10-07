using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private CharacterGroup _group;

        [SerializeField]
        private float _flyPower;

        public void Constructor(CharacterGroup ownerGroup)
        {
            _group = ownerGroup;
        }

        protected virtual void FixedUpdate()
        {
            var direction = transform.forward;
            transform.position += direction * _flyPower;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IBulletObstacable obstacle))
            {
                obstacle.Hit(this);
            }
        }
    }
}


