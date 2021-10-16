using HelicopterAttack.Characters.General;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class PlayerAim : AreaAim
    {
        [SerializeField]
        private Transform _crosshair;

        public override Vector3 GetTargetPosition()
        {
            return IsTargetVisible() ? Target.transform.position : _crosshair.transform.position;
        }

        private void Update()
        {
            
        }
    }
}