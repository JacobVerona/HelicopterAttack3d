using HelicopterAttack.Missions;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public class MissionDetails : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textPrefab;

        [SerializeField]
        private Mission _currentMission;

        [SerializeField]
        private RectTransform _goalsDescriptionArea;

        [SerializeField]
        private TMP_Text _completeMissionPercentsText;

        private Dictionary<TargetGoal, TMP_Text> _visibleGoalsDescription = new Dictionary<TargetGoal, TMP_Text>();

        public void Constructor(Mission mission)
        {
            _currentMission = mission;
        }

        private void Awake()
        {
            UpdateUI();
        }

        private void OnEnable()
        {
            _currentMission.GoalCompleted.AddListener(RemoveGoalUI);
        }

        private void OnDisable()
        {
            _currentMission.GoalCompleted.RemoveListener(RemoveGoalUI);
        }

        public void UpdateUI()
        {
            var goals = _currentMission.UncompletedGoals;

            foreach (var goal in goals)
            {
                var goalDescription = Instantiate(_textPrefab, _goalsDescriptionArea);
                _visibleGoalsDescription.Add(goal, goalDescription);

                goalDescription.text = goal.Description;
            }

            UpdatePercents();
        }

        public void RemoveGoalUI(TargetGoal goal)
        {
            if (_visibleGoalsDescription.TryGetValue(goal, out TMP_Text text))
            {
                Destroy(text.gameObject);
            }
            _visibleGoalsDescription.Remove(goal);

            UpdatePercents();
        }

        private void UpdatePercents()
        {
            _completeMissionPercentsText.text = $"{(int)(_currentMission.CompletedGoals.Count() / (float)_currentMission.Goals.Count() * 100f)}%";
        }
    }
}
