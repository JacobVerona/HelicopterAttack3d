using HelicopterAttack.Characters.General.AI;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.Hummer
{
    [RequireComponent(typeof(PatrolState), typeof(AttackState))]
    public class FollowState : AIState
    {
        [SerializeField] 
        private NavMeshAgent _agent;

        [SerializeField] 
        private HummerAim _vision;

        private readonly YieldInstruction _waitTime = new WaitForSeconds(2f);

        protected override void OnEntry ()
        {
            StartCoroutine(nameof(StateTick));
        }

        protected override void OnExit ()
        {
            StopCoroutine(nameof(StateTick));
        }

        private IEnumerator StateTick ()
        {
            while (true)
            {
                if (_vision.IsTargetVisible() == false)
                {
                    StateMachine.SetState<PatrolState>();
                    break;
                }

                if (Vector2.Distance(new Vector2(_agent.transform.position.x, _agent.transform.position.z),
                    new Vector2(_vision.GetTargetPosition().x, _vision.GetTargetPosition().z)) <= _agent.stoppingDistance)
                {
                    StateMachine.SetState<AttackState>();
                    break;
                }

                _agent.SetDestination(_vision.GetTargetPosition());
                
                yield return _waitTime;
            }
        }
    }
}



