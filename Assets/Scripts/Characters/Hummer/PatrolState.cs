using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Groups;
using HelicopterAttack.Characters.General.Combat;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.Hummer
{
    public class PatrolState : AIState
    {
        private const float _checkStoppingDistance = 0.01f;

        private readonly NavMeshAgent _agent;
        private readonly CharacterAim _vision;
        private readonly IPatrolPath _patrolPath;

        private float _chachedStoppingDistance;

        public PatrolState(NavMeshAgent agent, CharacterAim aim, IPatrolPath patrolPath)
        {
            _agent = agent;
            _vision = aim;
            _patrolPath = patrolPath;
        }

        public override void OnEntry ()
        {
            _chachedStoppingDistance = _agent.stoppingDistance;
            _agent.stoppingDistance = 0f;
        }

        public override void OnExit ()
        {
            _agent.stoppingDistance = _chachedStoppingDistance;
        }

        public override void OnAIUpdate()
        {
            var patrolPosition = _patrolPath.UpdatePatrolPosition(_agent.transform.position, _checkStoppingDistance);
            _agent.SetDestination(patrolPosition);
        }

        public bool TargetFoundTransition()
        {
            return _vision.FindNearestTarget(out CharacterGroup enemy);
        }
    }
}



