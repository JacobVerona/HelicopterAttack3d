using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    [RequireComponent(
    typeof(HelicopterMovement),
    typeof(HelicopterCannon))]
    public class HelicopterBrain : MonoBehaviour
    {
        private InputMap _inputMap;

        [SerializeField]
        private HelicopterMovement _movement;

        [SerializeField]
        private CharacterGun _combat;

        [SerializeField]
        private HelicopterAim _aim;

        [SerializeField]
        private CharacterGroup _group;

        [SerializeField]
        private Transform _crosshair;

        protected virtual void Awake ()
        {
            _inputMap = new InputMap();
        }

        protected virtual void OnEnable ()
        {
            _inputMap.Enable();

            _inputMap.Main.Attack.performed += OnAttack;
        }

        protected virtual void OnDisable ()
        {
            _inputMap.Main.Attack.performed -= OnAttack;
        }

        protected virtual void Update ()
        {
            var movementInput = _inputMap.Main.Movement.ReadValue<Vector2>();
            var rotationInput = _inputMap.Main.Rotation.ReadValue<Vector2>();

            _movement.Move(movementInput);
            _movement.Rotate(rotationInput);
        }

        private void OnAttack (UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (Physics.Raycast(transform.position, _crosshair.transform.position - transform.position, out RaycastHit hit))
            {
                _aim.transform.position = hit.point;

                if (_aim.FindNearestTarget(out CharacterGroup enemy)
                    && _group.IsAggressive(enemy))
                {
                    _combat.TryShoot(_aim.GetTargetPosition());
                }
                else
                {
                    _combat.TryShoot(hit.point);
                }
            }
        }
    }
}