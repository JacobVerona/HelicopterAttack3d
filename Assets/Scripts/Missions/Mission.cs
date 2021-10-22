using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HelicopterAttack.StateMachine;
using HelicopterAttack.Characters;
using HelicopterAttack.Characters.General.Groups;
using System.Linq;

namespace HelicopterAttack.Missions
{
    public sealed class Mission : MonoBehaviour
    {
        public UnityEvent<TargetGoal> GoalCompleted;
        public UnityEvent MissionCompleted;

        public event Action GoalsCountChanged; 

        [SerializeField]
        private List<TargetGoal> _targetGoal;
        
        public IEnumerable<TargetGoal> Goals { get => _targetGoal; }

        public IEnumerable<TargetGoal> UncompletedGoals { get => _targetGoal.Where(e => e.IsCompleted == false); }
        public IEnumerable<TargetGoal> CompletedGoals { get => _targetGoal.Where(e => e.IsCompleted); }

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
            GoalsCountChanged?.Invoke();
        }

        private void OnGoalCompleted(TargetGoal target)
        {
            GoalCompleted?.Invoke(target);

            if (_targetGoal.Where(goal => goal.IsCompleted == false).Any())
            {
                MissionCompleted?.Invoke();
            }
        }
    }
}