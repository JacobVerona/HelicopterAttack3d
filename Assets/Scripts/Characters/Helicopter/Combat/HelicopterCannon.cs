using HelicopterAttack.Characters.General.Combat;
using HelicopterAttack.Characters.General.Groups;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class HelicopterCannon : CharacterGun
    {
        [SerializeField]
        private Bullet _bulletPrefab;

        [SerializeField]
        private CharacterGroup _group;

        [SerializeField]
        private Transform[] _gunsPosition;

        public override void TryShoot (Vector3 position)
        {
            for (int i = 0; i < _gunsPosition.Length; i++)
            {
                var bullet = Instantiate(_bulletPrefab, _gunsPosition[i].position, Quaternion.identity);
                bullet.Constructor(_group);
                bullet.transform.forward = position - bullet.transform.position;
            }
        }
    }
}