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

        public bool IsBinded { get => _target != null; }

        private void Awake()
        {
            if (_target != null)
            {
                Bind(_target);
            }
        }

        private void Bind(CharacterHealth target)
        {
            _target = target;
            _target.Health.ValueChanged += OnValueChanged;
            OnValueChanged(_target.Health.BaseValue);
        }

        private void Unbind()
        {
            if (IsBinded == false)
                return;

            _target.Health.ValueChanged -= OnValueChanged;
            _target = null;
        }

        public void Rebind(CharacterHealth target)
        {
            Unbind();
            Bind(target);
        }

        private void OnValueChanged(float value)
        {
            _slider.value = value / _target.MaxHealth.BaseValue;
        }
    }
}
