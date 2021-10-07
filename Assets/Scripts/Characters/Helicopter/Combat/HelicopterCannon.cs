using HelicopterAttack.Characters.General.Combat;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class HelicopterCannon : CharacterGun
    {
        [SerializeField]
        private Bullet _bulletPrefab;

        [SerializeField]
        private Transform[] _gunsPosition;

        public override void TryShoot (Vector3 position)
        {
            for (int i = 0; i < _gunsPosition.Length; i++)
            {
                var bullet = Instantiate(_bulletPrefab, _gunsPosition[i].position, Quaternion.identity);
                bullet.transform.forward = position - bullet.transform.position;
            }
        }
    }
}