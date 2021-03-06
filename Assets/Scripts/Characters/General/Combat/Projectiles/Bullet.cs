using HelicopterAttack.Characters.General.Groups;
using HelicopterAttack.Global;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private SpaceFloatEvent _onBulletHitEvent;

        [SerializeField]
        private CharacterGroup _group;

        [SerializeField]
        private float _flyPower;

        [SerializeField]
        private float _damage;

        [SerializeField]
        private float _explosionPower;

        public Damage Damage
        {
            get => new Damage() { Owner = _group, Value = _damage };
        }

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
            if (other.gameObject.TryGetComponent(out CharacterGroup group)
                && _group.IsFiendly(group))
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out IBulletObstacleable obstacle))
            {
                obstacle.OnHit(this);
                _onBulletHitEvent.Invoke(new SpaceEventData(transform.position, _explosionPower));

                Destroy(gameObject);
            }
        }
    }
}


