using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HelicopterAttack.Missions
{
    public sealed class Mission : MonoBehaviour
    {
        public UnityEvent<GoalTarget> GoalCompleted;
        public UnityEvent MissionCompleted;

        public event Action GoalsCountChanged; 

        [SerializeField]
        private List<GoalTarget> _goalTargets;

        private List<GoalTarget> _completedGoals = new List<GoalTarget>();

        public IEnumerable<GoalTarget> Goals { get => _goalTargets; }
        public IEnumerable<GoalTarget> CompletedGoals { get => _completedGoals; }

        private void OnEnable()
        {
            foreach (var goalTarget in _goalTargets)
            {
                goalTarget.Completed += OnGoalCompleted;
            }
        }

        private void OnDisable()
        {
            foreach (var goalTarget in _goalTargets)
            {
                goalTarget.Completed -= OnGoalCompleted;
            }
        }

        public void RegisterTarget(GoalTarget target)
        {
            _goalTargets.Add(target);
            target.Completed += OnGoalCompleted;
            GoalsCountChanged?.Invoke();
        }

        private void OnGoalCompleted(GoalTarget target)
        {
            _goalTargets.Remove(target);
            _completedGoals.Add(target);
            GoalCompleted?.Invoke(target);

            if (_goalTargets.Count <= 0)
            {
                MissionCompleted?.Invoke();
            }
            GoalsCountChanged?.Invoke();
        }
    }
}