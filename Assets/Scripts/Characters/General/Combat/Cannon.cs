using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public class Cannon : CharacterGun
    {
        private const float AngleFieldOfView = 1f;

        [SerializeField]
        private CharacterAim _aim;

        [SerializeField]
        private CharacterGroup _group;

        [SerializeField]
        private Bullet _bulletPrefab;

        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private float _rotationSpeed;

        private bool _isReadyToShoot;

        public override void TryShoot (Vector3 position)
        {
            if (_isReadyToShoot == false)
            {
                return;
            }

            var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.Constructor(_group);
            bullet.transform.forward = position - bullet.transform.position;
        }

        public void Update ()
        {
            float angle = 0f;
            _aim.FindNearestTarget(out CharacterGroup target);

            angle = _aim.IsTargetVisible() == false ?
                AngleBetweenSelfTarget(_aim.transform.position) : AngleBetweenSelfTarget(_aim.GetTargetPosition());

            RotateHead(angle);

            _isReadyToShoot = Mathf.Abs(angle) <= AngleFieldOfView;
        }

        private float AngleBetweenSelfTarget(Vector3 targetPosition)
        {
            Vector3 rotationDirection = targetPosition - transform.position;

            return Vector2.SignedAngle(new Vector2(rotationDirection.x, rotationDirection.z),
                new Vector2(transform.forward.x, transform.forward.z));

        }

        private void RotateHead (float angle)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation,
               Quaternion.Euler(transform.localEulerAngles + new Vector3(0, angle, 0)), _rotationSpeed * Time.deltaTime);
        }
    }
}