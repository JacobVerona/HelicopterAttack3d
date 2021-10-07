using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public class Cannon : CharacterGun
    {
        private const float AngleFieldOfView = 1f;

        [SerializeField]
        private CharacterAim _aim;

        [SerializeField]
        private Bullet _bulletPrefab;

        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private float _rotationSpeed;

        private bool _isReadyToShoot;

        private float AngleBetweenSelfTarget
        {
            get
            {
                Vector3 rotationDirection = _aim.GetTargetPosition() - transform.position;

                return Vector2.SignedAngle(new Vector2(rotationDirection.x, rotationDirection.z),
                    new Vector2(transform.forward.x, transform.forward.z));
            }
        }

        public override void TryShoot (Vector3 position)
        {
            if (_isReadyToShoot == false)
            {
                return;
            }

            var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.transform.forward = position - bullet.transform.position;
        }

        public void Update ()
        {
            if (_aim.IsTargetVisible() == false)
            {
                return;
            }

            float angle = AngleBetweenSelfTarget;

            RotateHead(angle);

            _isReadyToShoot = Mathf.Abs(angle) <= AngleFieldOfView;
        }

        private void RotateHead (float angle)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
               Quaternion.Euler(transform.eulerAngles + new Vector3(0, angle, 0)), _rotationSpeed * Time.deltaTime);
        }
    }
}