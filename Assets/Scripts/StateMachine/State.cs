namespace HelicopterAttack.StateMachine
{
    public abstract class State
    {
        public virtual void OnEntry() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnRegistered() { }
        public virtual void OnUnregistered() { }
    }
}