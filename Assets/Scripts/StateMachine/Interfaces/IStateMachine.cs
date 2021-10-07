using System.Collections.Generic;

namespace Characters.StateMachine
{
    public interface IStateMachine
    {
        void SetState<T> () where T : IStateable;
    }
}