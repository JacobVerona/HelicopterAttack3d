namespace HelicopterAttack.StateMachine
{
    public interface ISMConfigurator<TStateBase>
         where TStateBase : State
    {
        ITransitionRegister RegisterDefaultStateAs<T>(TStateBase state) where T : State;
        ITransitionRegister RegisterStateAs<T>(TStateBase state) where T : State;
    }
}