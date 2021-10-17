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
        private float _moveSpeed = 100f;

        [SerializeField]
        private float _aimMoveSpeed = 500f;

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
            transform.Translate(_moveSpeed * Time.deltaTime * input);
            transform.localPosition = Vector2.ClampMagnitude(transform.localPosition, _movementRange);
        }

        private void AimTarget()
        {
            var ray = Camera.main.ScreenPointToRay(transform.position);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _groundMask))
            {
                _aim.transform.position = MoveTo(_aim.transform.position, hit.point, _aimMoveSpeed);

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

        private static Vector3 MoveTo(Vector3 current, Vector3 target, float speed)
        {
            return Vector3.MoveTowards(current, target, speed * Time.deltaTime);
        }
    }
}
