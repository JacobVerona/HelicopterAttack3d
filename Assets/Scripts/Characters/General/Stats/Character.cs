using Characters.RPG;
using System;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    public class Character : MonoBehaviour
    {
        public event Action Spawned;
        public event Action Died;

        [SerializeField]
        private float _startHealth;

        public CharacterAttribute MaxHealth { get; private set; } = new CharacterAttribute(0);
        public CharacterAttribute Health { get; private set; } = new CharacterAttribute(0);

        private void Awake()
        {
            MaxHealth.AddValue(_startHealth, CharacterAttribute.ValueModifier.Base);
            Health.AddValue(MaxHealth.Value, CharacterAttribute.ValueModifier.Base);
        }

        private void OnEnable()
        {
            Health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            Health.ValueChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float health)
        {
            if (health <= 0f)
            {
                Died?.Invoke();
            }
        }
    }
}