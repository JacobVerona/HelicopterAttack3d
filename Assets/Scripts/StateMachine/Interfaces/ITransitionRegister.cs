using System;

namespace HelicopterAttack.StateMachine
{
    public interface ITransitionRegister
    {
        ITransitionRegister WithTransitionTo<T>(Func<bool> condition) where T : State;
    }
}