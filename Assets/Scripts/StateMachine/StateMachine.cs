using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.StateMachine
{
    public abstract class StateMachine<TStateBase> : StateMachineBase
        where TStateBase : IStateable
    {
        protected Dictionary<Type, TStateBase> States = new Dictionary<Type, TStateBase>();

        private TStateBase _currentState;

        [SerializeField] 
        private TStateBase _defaultState;

        public event Action StateChanged;

        public override IEnumerable<Type> StateTypes => States.Keys;

        public TStateBase CurrentState
        {
            get => _currentState ?? _defaultState;
            private set
            {
                CurrentState.Exit();
                _currentState = value;

                if (enabled)
                {
                    CurrentState.Entry();
                }

                StateChanged?.Invoke();
            }
        }

        private void OnEnable ()
        {
            CurrentState.Entry();
        }

        private void OnDisable ()
        {
            CurrentState.Exit();
        }

        private void OnDestroy ()
        {
            CurrentState.Exit();
            foreach (var state in States.Values)
            {
                state.Unregistered();
            }
        }

        public void RegisterState (TStateBase state)
        {
            if (States.ContainsKey(state.GetType()))
            {
                Debug.LogError($"State with given type ({state.GetType()}) is currently registered");
            }
            else
            {
                States.Add(state.GetType(), state);
                ConfigureState(state);
                state.Registered();
            }
        }

        public void UnregisterState(TStateBase state)
        {
            if (States.ContainsKey(state.GetType()))
            {
                state.Unregistered();
                States.Remove(state.GetType());
            }
            else
            {
                Debug.LogError($"State with given type ({state.GetType()}) is currently unregistered");
            }
        }
        public void SetState<T> ()
            where T : TStateBase
        {
            SetState(typeof(T));
        }

        public override void SetState (Type type)
        {
            if (States.TryGetValue(type, out TStateBase state))
            {
                CurrentState = state;
            }
            else
            {
                Debug.LogError($"The given state {name} is not register in state machine");
            }
        }

        protected virtual void ConfigureState (in TStateBase state) { }
    }
}