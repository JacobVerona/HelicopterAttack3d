using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class HelicopterMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveAngleRotation = 35f;

        [SerializeField]
        private float _movementSpeed = 4f;

        [SerializeField]
        private float _rotationSpeed = 120f;

        private Vector3 _velocity;
        private Quaternion _baseQuaternion;
        private Quaternion _lookDirectionRotation;

        protected void Update ()
        {
            transform.rotation = _baseQuaternion * _lookDirectionRotation;
        }

        public void Move (Vector2 horizontalVelocity)
        {
            _baseQuaternion = Quaternion.RotateTowards(_baseQuaternion, Quaternion.AngleAxis(_moveAngleRotation,
                new Vector3(horizontalVelocity.y, 0, -horizontalVelocity.x)), _rotationSpeed * Time.deltaTime);

            _velocity = new Vector3(horizontalVelocity.x,
                0,
                horizontalVelocity.y);

            transform.Translate(_movementSpeed * _velocity * Time.deltaTime, Space.World);
        }

        public void Rotate (Vector2 rotationDirection)
        {
            float angle = Vector2.SignedAngle(rotationDirection, new Vector2(transform.forward.x, transform.forward.z));

            _lookDirectionRotation = Quaternion.RotateTowards(_lookDirectionRotation,
                Quaternion.Euler(_lookDirectionRotation.eulerAngles + new Vector3(0, angle, 0)), _rotationSpeed * Time.deltaTime);
        }
    }
}
