using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HelicopterAttack.Missions
{
    public sealed class Mission : MonoBehaviour
    {
        public UnityEvent<GoalTarget> GoalCompleted;
        public UnityEvent MissionCompleted;

        [SerializeField]
        private List<GoalTarget> _goalTargets;

        public IEnumerable<GoalTarget> GoalTargets { get => _goalTargets; }

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
        }

        private void OnGoalCompleted(GoalTarget target)
        {
            _goalTargets.Remove(target);
            GoalCompleted?.Invoke(target);

            if (_goalTargets.Count <= 0)
            {
                MissionCompleted?.Invoke();
            }
        }
    }
}