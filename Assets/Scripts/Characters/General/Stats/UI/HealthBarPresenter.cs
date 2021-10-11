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

        public void Constuctor(CharacterHealth target)
        {
            _target = target;
            enabled = true;
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
