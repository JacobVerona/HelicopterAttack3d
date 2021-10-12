namespace HelicopterAttack.StateMachine
{
    public interface IStateMachine
    {
        void SetState<T> () where T : IStateable;
    }
}