using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat.UI
{
    public class TargetBracket : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private float _bracketScale = 100f;

        [SerializeField]
        private HealthBarPresenter _healthBarPresenter;

        private CharacterGroup _target;

        public CharacterGroup Target
        {
            get => _target;
            set
            {
                _target = value;

                if (_target == null
                    && gameObject.activeSelf == false)
                    return;

                gameObject.SetActive(_target != null);
                UpdateView();
            }
        }

        private void Update()
        {
            if (Target == null)
                return;

            ResizeBracket(Target.Bounds);
        }

        private void UpdateView()
        {
            if (Target == null) 
                return;

            if (Target.TryGetComponent(out CharacterHealth health))
            {
                _healthBarPresenter.Rebind(health);
            }

            ResizeBracket(Target.Bounds);
        }

        private void ResizeBracket(Bounds bounds)
        {
            _rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.center.y, bounds.center.z));
            var scale = new Vector3(bounds.size.x, bounds.size.z, bounds.size.z) * _bracketScale;
            _rectTransform.sizeDelta = scale;
        }
    }
}
