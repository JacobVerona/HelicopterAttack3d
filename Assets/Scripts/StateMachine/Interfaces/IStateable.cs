﻿namespace Characters.StateMachine
{
    public interface IStateable
    {
        void Registered ();
        void Entry ();
        void Exit ();
        void Unregistered ();
    }
}