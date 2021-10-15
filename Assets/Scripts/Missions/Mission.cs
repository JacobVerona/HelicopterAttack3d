using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HelicopterAttack.StateMachine;
using HelicopterAttack.Characters;
using HelicopterAttack.Characters.General.Groups;

namespace HelicopterAttack.Missions
{
    public sealed class Mission : MonoBehaviour
    {
        public UnityEvent<TargetGoal> GoalCompleted;
        public UnityEvent MissionCompleted;

        public event Action TargetGoalsCountChanged; 

        [SerializeField]
        private List<TargetGoal> _targetGoal;

        private List<TargetGoal> _completedGoals = new List<TargetGoal>();
        
        public IEnumerable<TargetGoal> Goals { get => _targetGoal; }
        public IEnumerable<TargetGoal> CompletedGoals { get => _completedGoals; }

        private void OnEnable()
        {
            foreach (var goalTarget in _targetGoal)
            {
                goalTarget.Completed += OnGoalCompleted;
            }
        }

        private void OnDisable()
        {
            foreach (var goalTarget in _targetGoal)
            {
                goalTarget.Completed -= OnGoalCompleted;
            }
        }

        public void RegisterTarget(TargetGoal target)
        {
            _targetGoal.Add(target);
            target.Completed += OnGoalCompleted;
            TargetGoalsCountChanged?.Invoke();
        }

        private void OnGoalCompleted(TargetGoal target)
        {
            _targetGoal.Remove(target);
            _completedGoals.Add(target);
            GoalCompleted?.Invoke(target);

            if (_targetGoal.Count <= 0)
            {
                MissionCompleted?.Invoke();
            }
            TargetGoalsCountChanged?.Invoke();
        }
    }

    public class GameStateMachine : StateMachine<GameState>
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        protected override void ConfigureState(in GameState state)
        {
            
        }
    }

    public class GameState : MonoState
    {

    }

    public class PlayState : GameState
    {
        [SerializeField]
        private Player _player;


    }

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private CameraFXShake _fxShake;

        [SerializeField]
        private CharacterGroup _characterGroup;

        public CameraFXShake FXShake { get => _fxShake; }
        public CharacterGroup CharacterGroup { get => _characterGroup; }

        public void CreatePlayer()
        {

        }
    }
}