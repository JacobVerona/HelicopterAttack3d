using System;
using System.Collections.Generic;

namespace HelicopterAttack.StateMachine
{
    public class RegisteredState<TState> : ITransitionRegister
        where TState : State
    {
        private List<StateTransition> _transitions;

        public TState State { get; private set; }
        public IEnumerable<StateTransition> Transitions { get => _transitions; }
        
        public RegisteredState(TState state)
        {
            State = state;
            _transitions = new List<StateTransition>();
        }

        public ITransitionRegister WithTransitionTo<T>(Func<bool> condition) where T : State
        {
            _transitions.Add(new StateTransition(condition, typeof(T)));
            return this;
        }
    }
}