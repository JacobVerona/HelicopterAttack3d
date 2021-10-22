using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Groups;
using HelicopterAttack.Characters.General.Combat;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.Hummer
{
    [RequireComponent(typeof(FollowState))]
    public class PatrolState : AIState
    {
        private const float _checkStoppingDistance = 0.01f;

        [SerializeField]
        private NavMeshAgent _agent;

        [SerializeField]
        private CharacterAim _vision;

        [SerializeField]
        private float _patrolRadius = 10f;

        private IPatrolPath _patrolPath;
        private readonly YieldInstruction _waitTime = new WaitForSeconds(1f);

        private float _chachedStoppingDistance;

        public override void Awake ()
        {
            base.Awake();
            _patrolPath = new RandomPatrolPath(transform.position, _patrolRadius);
        }

        protected override void OnEntry ()
        {
            _chachedStoppingDistance = _agent.stoppingDistance;
            _agent.stoppingDistance = 0f;

            StartCoroutine(nameof(AITick));
        }

        protected override void OnExit ()
        {
            _agent.stoppingDistance = _chachedStoppingDistance;
            StopCoroutine(nameof(AITick));
        }

        private IEnumerator AITick ()
        {
            while (true)
            {
                if (_vision.FindNearestTarget(out CharacterGroup enemy))
                {
                    StateMachine.SetState<FollowState>();
                    break;
                }

                _agent.SetDestination(
                    _patrolPath.UpdatePatrolPosition(_agent.transform.position, _checkStoppingDistance)
                    );

                yield return _waitTime;
            }
        }
    }
}



