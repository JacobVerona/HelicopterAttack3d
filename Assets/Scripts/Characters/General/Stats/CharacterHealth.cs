using HelicopterAttack.Global;
using HelicopterAttack.RPG;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HelicopterAttack.Characters
{
    public class CharacterHealth : MonoBehaviour
    {
        public event Action Died;

        public UnityEvent<Damage> Damaged;

        [SerializeField]
        private SpaceFloatEvent _explosion;

        [SerializeField]
        private float _startHealth;

        public CharacterAttribute MaxHealth { get; private set; } = new CharacterAttribute(0);
        public CharacterAttribute Health { get; private set; } = new CharacterAttribute(0);

        private void Awake()
        {
            MaxHealth.AddValue(_startHealth, CharacterAttribute.ValueModifier.Base);
            Health.AddValue(_startHealth, CharacterAttribute.ValueModifier.Base);
        }

        private void OnEnable()
        {
            Health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            Health.ValueChanged -= OnHealthChanged;
        }

        public void DealDamage(Damage damage)
        {
            damage.Deal(Health);
            Damaged?.Invoke(damage);
        }

        private void OnHealthChanged(float health)
        {
            if (health <= 0f)
            {
                Died?.Invoke();
                _explosion?.Invoke(new SpaceEventData(transform.position, 1f));
                Destroy(gameObject);
            }
        }
    }
}