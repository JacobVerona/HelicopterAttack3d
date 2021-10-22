using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.StateMachine
{
    public abstract class StateMachine<TStateBase> : StateMachine, IStateChanger, ISMConfigurator<TStateBase>
        where TStateBase : State
    {
        private Dictionary<Type, RegisteredState<TStateBase>> _states = new Dictionary<Type, RegisteredState<TStateBase>>();
        private RegisteredState<TStateBase> _current;

        public override event Action StateChanged;

        public override IEnumerable<Type> StateTypes => _states.Keys;

        public TStateBase CurrentState
        {
            get => _current.State;
        }

        private void Awake()
        {
            ConfigureStateMachine(this);
            OnCreated();
        }

        private void OnEnable ()
        {
            CurrentState.OnEntry();
            OnEnabled();
        }

        private void OnDisable ()
        {
            CurrentState.OnExit();
            OnDisabled();
        }

        private void OnDestroy ()
        {
            CurrentState.OnExit();
            foreach (var registeredStates in _states.Values)
            {
                registeredStates.State.OnUnregistered();
            }
            OnDeleted();
        }

        private void Update()
        {
            CurrentState.OnUpdate();

            foreach (var transition in _current.Transitions)
            {
                if (transition.Check(this))
                {
                    break;
                }
            }

            OnUpdate();
        }

        private void FixedUpdate()
        {
            CurrentState.OnFixedUpdate();
            OnFixedUpdate();
        }

        private void LateUpdate()
        {
            CurrentState.OnLateUpdate();
            OnLateUpdate();
        }

        public void UnregisterState(TStateBase state)
        {
            if (_states.ContainsKey(state.GetType()))
            {
                state.OnUnregistered();
                _states.Remove(state.GetType());
            }
            else
            {
                Debug.LogError($"State with given type ({state.GetType()}) is currently unregistered");
            }
        }

        public override void SetState<T> ()
        {
            SetState(typeof(T));
        }

        public override void SetState (Type type)
        {
            if (_states.TryGetValue(type, out RegisteredState<TStateBase> state))
            {
                _current = state;
                StateChanged?.Invoke();
            }
            else
            {
                Debug.LogError($"The given state {name} is not register in state machine");
            }
        }

        public ITransitionRegister RegisterStateAs<T>(TStateBase state) where T : State
        {
            var type = typeof(T);

            if (_states.ContainsKey(type))
            {
                Debug.LogError($"State with given type ({type}) is currently registered, it will be replaced by new");
            }

            RegisteredState<TStateBase> createdState = new RegisteredState<TStateBase>(state);
            _states[type] = createdState;
            state.OnRegistered();

            return createdState;
        }

        public ITransitionRegister RegisterDefaultStateAs<T>(TStateBase state) where T : State
        {
            if (_current != null)
            {
                Debug.LogWarning("The default state is already registered");
            }

            var registeredState = RegisterStateAs<T>(state);
            _current = (RegisteredState<TStateBase>)registeredState;
            return registeredState;
        }

        protected override void ValidateTransitions()
        {
            foreach (var state in _states)
            {
                foreach (var transition in state.Value.Transitions)
                {
                    if (_states.ContainsKey(transition.To) == false)
                    {
                        Debug.LogError("Statemachine transitions validation error");
                        throw new InvalidOperationException($"The required state with type {transition.To} is not registered in statemachine");
                    }
                }
            }
            Debug.Log("Statemachine transitions validation success");
        }

        protected abstract void ConfigureStateMachine(in ISMConfigurator<TStateBase> stateMachine);

        protected virtual void OnCreated() { }
        protected virtual void OnDeleted() { }
        protected virtual void OnEnabled() { }
        protected virtual void OnDisabled() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnFixedUpdate() { }
        protected virtual void OnLateUpdate() { }
    }

    public abstract class StateMachine : MonoBehaviour, IStateChanger
    {
        public abstract event Action StateChanged;

        public abstract IEnumerable<Type> StateTypes { get; }

        public abstract void SetState<T>() where T : State;
        public abstract void SetState(Type type);
        protected abstract void ValidateTransitions();
    }
}