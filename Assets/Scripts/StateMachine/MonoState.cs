using UnityEngine;

namespace HelicopterAttack.StateMachine
{
    public abstract class MonoState : MonoBehaviour, IStateable
    {
        public virtual void Awake ()
        {
            enabled = false;
        }

        public void Entry ()
        {
            enabled = true;
            OnEntry();
        }

        public void Exit ()
        {
            enabled = false;
            OnExit();
        }

        public void Registered () 
        {
            enabled = false;
            OnRegistered();
        }

        public void Unregistered () 
        {
            OnUnregistered();
        }

        protected virtual void OnRegistered () { }

        protected virtual void OnUnregistered () { }

        protected virtual void OnEntry () { }

        protected virtual void OnExit () { }
    }
}
