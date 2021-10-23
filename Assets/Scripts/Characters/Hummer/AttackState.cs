using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Combat;

namespace HelicopterAttack.Characters.Hummer
{
    public class AttackState : AIState
    {
        private readonly CharacterAim _vision;
        private readonly CharacterGun _gun;
        private readonly float _followDistance;
        
        public AttackState(CharacterAim characterAim, CharacterGun characterGun, float followDistance)
        {
            _vision = characterAim;
            _gun = characterGun;
            _followDistance = followDistance;
        }

        public override void OnAIUpdate()
        {
            _gun.TryShoot(_vision.GetTargetPosition());
        }

        public bool TargetIsntVisibleTransition()
        {
            return _vision.IsTargetVisible() == false;
        }

        public bool TargetTooFarTransition()
        {
            return _vision.DistanceToTarget > _followDistance;
        }
    }
}



