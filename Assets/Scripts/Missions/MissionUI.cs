using System.Text;
using TMPro;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public class MissionUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private Mission _mission;

        private void Awake()
        {
            UpdateUIText();
        }

        private void OnEnable()
        {
            _mission.GoalsCountChanged += UpdateUIText;
        }

        private void OnDisable()
        {
            _mission.GoalsCountChanged -= UpdateUIText;
        }

        private void UpdateUIText()
        {
            var stringBuilder = new StringBuilder();

            foreach (var goal in _mission.Goals)
            {
                stringBuilder.Append(goal.Description + "\n");
            }
            _text.text = stringBuilder.ToString();
        }
    }
}