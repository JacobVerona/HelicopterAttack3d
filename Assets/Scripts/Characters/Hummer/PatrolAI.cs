using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Combat;
using UnityEngine.AI;
using HelicopterAttack.StateMachine;
using UnityEngine;

namespace HelicopterAttack.Characters.Hummer
{
    public class PatrolAI : AIStateMachine
    {
        [SerializeField]
        private NavMeshAgent _agent;

        [SerializeField]
        private CharacterAim _aim;

        [SerializeField]
        private CharacterGun _gun;

        [SerializeField]
        private float _patrolRadius;

        [SerializeField]
        private float _followDistance;

        protected override void ConfigureStateMachine(in ISMConfigurator<AIState> stateMachine)
        {
            RegisterPatrolState(stateMachine);
            RegisterFollowState(stateMachine);
            RegisterAttackState(stateMachine);
        }

        private void RegisterPatrolState(ISMConfigurator<AIState> stateMachine)
        {
            var patrolState = new PatrolState(_agent, _aim, new RandomPatrolPath(transform.position, _patrolRadius));

            stateMachine.RegisterDefaultStateAs<PatrolState>(patrolState)
                .WithTransitionTo<FollowState>(patrolState.TargetFoundTransition);
        }

        private void RegisterFollowState(ISMConfigurator<AIState> stateMachine)
        {
            var followState = new FollowState(_agent, _aim);

            stateMachine.RegisterStateAs<FollowState>(followState)
                .WithTransitionTo<PatrolState>(followState.TargetIsntVisibleTransition)
                .WithTransitionTo<AttackState>(followState.TargetGotTransition);
        }

        private void RegisterAttackState(ISMConfigurator<AIState> stateMachine)
        {
            var attackState = new AttackState(_aim, _gun, _followDistance);

            stateMachine.RegisterStateAs<AttackState>(attackState)
                .WithTransitionTo<FollowState>(attackState.TargetIsntVisibleTransition);
        }
    }
}



