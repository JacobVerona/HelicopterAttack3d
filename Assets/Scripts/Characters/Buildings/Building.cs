using HelicopterAttack.Characters.General.Combat;
using System;

namespace HelicopterAttack.Characters.Buildings
{
    public class Building : CharacterArmor
    {
        public override void OnHit(Bullet bullet)
        {
            if (bullet is Rocket)
            {
                base.OnHit(bullet);
            }
        }
    }
}
