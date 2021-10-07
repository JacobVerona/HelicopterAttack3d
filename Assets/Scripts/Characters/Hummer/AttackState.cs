using HelicopterAttack.Characters.General.AI;
using HelicopterAttack.Characters.General.Combat;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.Hummer
{
    [RequireComponent(typeof(FollowState), typeof(PatrolState))]
    public class AttackState : AIState
    {
        [SerializeField]
        private NavMeshAgent _agent;

        [SerializeField]
        private CharacterAim _vision;

        [SerializeField]
        private CharacterGun _gun;

        [SerializeField]
        private float _followDistance;
        
        private readonly YieldInstruction _waitTime = new WaitForSeconds(1f);

        protected override void OnEntry ()
        {
            StartCoroutine(nameof(AITick));
        }

        protected override void OnExit ()
        {
            StopCoroutine(nameof(AITick));
        }

        private IEnumerator AITick ()
        {
            while (true)
            {
                if (_vision.IsTargetVisible() == false)
                {
                    StateMachine.SetState<PatrolState>();
                    break;
                }

                if (_vision.DistanceToTarget > _followDistance)
                {
                    StateMachine.SetState<FollowState>();
                    break;
                }

                for (int i = 0; i < 3; i++)
                {
                    _gun.TryShoot(_vision.GetTargetPosition());
                    yield return new WaitForSeconds(0.25f);
                }


                yield return _waitTime;
            }
        }
    }
}



