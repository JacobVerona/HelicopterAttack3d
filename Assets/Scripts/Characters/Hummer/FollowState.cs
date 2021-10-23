using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Combat;
using UnityEngine;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.Hummer
{
    public class FollowState : AIState
    {
        private readonly NavMeshAgent _agent;
        private readonly CharacterAim _vision;

        public FollowState(NavMeshAgent agent, CharacterAim aim)
        {
            _agent = agent;
            _vision = aim;
        }

        public override void OnAIUpdate()
        {
            _agent.SetDestination(_vision.GetTargetPosition());
        }

        public bool TargetIsntVisibleTransition()
        {
            return _vision.IsTargetVisible() == false;
        }

        public bool TargetGotTransition()
        {
            return Vector2.Distance(new Vector2(_agent.transform.position.x, _agent.transform.position.z),
                    new Vector2(_vision.GetTargetPosition().x, _vision.GetTargetPosition().z)) <= _agent.stoppingDistance;
        }
    }
}



