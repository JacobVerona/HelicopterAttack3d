using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class HelicopterBrain : MonoBehaviour
    {
        private InputMap _inputMap;

        [SerializeField]
        private HelicopterMovement _movement;

        [SerializeField]
        private CharacterGun _combat;

        [SerializeField]
        private CharacterAim _aim;

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

            _inputMap.Disable();
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
            _aim.FindNearestTarget(out CharacterGroup enemy);
            _combat.TryShoot(_aim.GetTargetPosition());
        }
    }
}