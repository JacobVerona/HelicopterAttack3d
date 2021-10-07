using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.StateMachine
{
    public abstract class StateMachineBase : MonoBehaviour
    {
        public abstract IEnumerable<Type> StateTypes { get; }
        public abstract void SetState (Type type);
    }
}