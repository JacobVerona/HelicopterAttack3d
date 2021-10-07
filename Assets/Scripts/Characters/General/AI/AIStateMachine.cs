using Characters.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace HelicopterAttack.Characters.General.AI
{
    [DisallowMultipleComponent]
    public class AIStateMachine : StateMachine<AIState>
    {
        protected void Awake ()
        {
            var states = GetComponents<AIState>();

            for (int i = 0; i < states.Length; i++)
            {
                RegisterState(states[i]);
            }
        }

        protected override void ConfigureState (in AIState state)
        {
            state.StateMachine = this;
        }
    }
}



