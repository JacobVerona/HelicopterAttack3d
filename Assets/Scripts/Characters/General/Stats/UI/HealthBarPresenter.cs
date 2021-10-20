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

        public void SetTarget(CharacterHealth target)
        {
            Unbind();

            _target = target;

            Bind();
        }

        public void Bind()
        {
            _target.Health.ValueChanged += OnValueChanged;
            OnValueChanged(_target.Health.BaseValue);
        }

        public void Unbind()
        {
            if (IsBinded == false) 
                return; 

            _target.Health.ValueChanged -= OnValueChanged;
            _target = null;
        }

        private void OnValueChanged(float value)
        {
            _slider.value = value / _target.MaxHealth.Value;
        }
    }
}
