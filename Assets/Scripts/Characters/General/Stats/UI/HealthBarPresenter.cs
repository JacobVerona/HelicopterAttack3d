using UnityEngine;
using UnityEngine.UI;

namespace HelicopterAttack.Characters
{
    public class HealthBarPresenter : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private CharacterHealth _target;

        public void Bind(CharacterHealth target)
        {
            if (_target != null)
            {
                _target.Health.ValueChanged -= OnValueChanged;
            }


            _target = target;

            _target.Health.ValueChanged += OnValueChanged;
            OnValueChanged(_target.Health.BaseValue);
        }

        private void OnEnable()
        {
            _target.Health.ValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            _target.Health.ValueChanged -= OnValueChanged;
        }

        private void Start()
        {
            OnValueChanged(_target.Health.Value);
        }

        private void OnValueChanged(float value)
        {
            _slider.value = value / _target.MaxHealth.Value;
        }
    }
}
