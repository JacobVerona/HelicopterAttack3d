using System;

namespace HelicopterAttack.StateMachine
{
    public interface IStateChanger
    {
        void SetState<T>() where T : State;
        void SetState(Type type);
    }
}