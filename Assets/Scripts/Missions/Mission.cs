using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
}