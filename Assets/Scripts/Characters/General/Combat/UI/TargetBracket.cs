using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat.UI
{
    public class TargetBracket : MonoBehaviour
    {
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
                if (_target != value)
                {
                    if (value == null)
                    {
                        _target = null;
                        gameObject.SetActive(false);
                        return;
                    }
                        
                    _target = value;
                    UpdateView();
                    gameObject.SetActive(true);
                }
            }
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (Target == null)
            {
                gameObject.SetActive(false);
                return;
            }

            ResizeBracket();
        }

        public void UpdateView()
        {
            if (Target.TryGetComponent(out CharacterHealth health))
            {
                _healthBarPresenter.Bind(health);
            }

            ResizeBracket();
        }

        private void ResizeBracket()
        {
            var bounds = Target.Bounds;

            _rectTransform.position = Camera.main.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.center.y, bounds.center.z));
            var scale = new Vector3(bounds.size.x, bounds.size.z, bounds.size.z) * _bracketScale;
            _rectTransform.sizeDelta = scale;
        }
    }
}
