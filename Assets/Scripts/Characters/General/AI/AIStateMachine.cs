using HelicopterAttack.StateMachine;
using System.Collections;
using UnityEngine;

namespace HelicopterAttack.Characters.General.AI
{
    public abstract class AIStateMachine : StateMachine<AIState>
    {
        [SerializeField]
        private float _aiUpdateSeconds = 1f;

        private YieldInstruction _waitTime;

        protected override void OnCreated()
        {
            _waitTime = new WaitForSeconds(_aiUpdateSeconds);
        }

        protected override void OnEnabled()
        {
            StartCoroutine(nameof(AIUpdate));
        }

        protected override void OnDisabled()
        {
            StopCoroutine(nameof(AIUpdate));
        }

        private IEnumerator AIUpdate()
        {
            while (true)
            {
                CurrentState.OnAIUpdate();
                yield return _waitTime;
            }
        }
    }
}