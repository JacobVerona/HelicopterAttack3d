using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Combat.UI;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class PlayerCrosshair : MonoBehaviour
    {
        [SerializeField]
        private float _movementRange = 50f;

        [SerializeField]
        private TargetBracket _bracket;

        [SerializeField]
        private CharacterAim _aim;

        [SerializeField]
        private float _crosshairMoveSpeed = 100f;

        [SerializeField]
        private LayerMask _groundMask;

        private InputMap _input;

        private void Awake()
        {
            _input = new InputMap();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            var rotationInput = _input.Main.Rotation.ReadValue<Vector2>();

            MoveCrosshair(rotationInput);
            AimTarget();
        }

        private void MoveCrosshair(Vector2 input)
        {
            transform.Translate(_crosshairMoveSpeed * Time.deltaTime * input);
            transform.localPosition = Vector2.ClampMagnitude(transform.localPosition, _movementRange);
        }

        private void AimTarget()
        {
            var ray = Camera.main.ScreenPointToRay(transform.position);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _groundMask))
            {
                _aim.transform.position = hit.point;

                if (_aim.FindNearestTarget(out CharacterGroup target))
                {
                    _bracket.Target = target;
                }
                else
                {
                    _bracket.Target = null;
                }
            }
        }
    }
}
