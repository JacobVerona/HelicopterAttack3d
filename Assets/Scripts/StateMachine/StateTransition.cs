using System;

namespace HelicopterAttack.StateMachine
{
    public class StateTransition
    {
        public readonly Type To;

        private readonly Func<bool> _condition;

        public StateTransition(Func<bool> condition, Type to)
        {
            _condition = condition;
            To = to;
        }

        public bool Check(IStateChanger stateChanger)
        {
            if (_condition.Invoke() == false)
                return false;

            stateChanger.SetState(To);
            return true;
        }
    }
}