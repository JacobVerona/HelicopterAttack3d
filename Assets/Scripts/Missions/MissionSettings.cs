using UnityEngine;
using UnityEngine.SceneManagement;

namespace HelicopterAttack.Missions
{
    [CreateAssetMenu(fileName = "MissionConfig", menuName = "HelicopterAttack/Missions/MissionSettings")]
    public class MissionSettings : ScriptableObject
    {
        [SerializeField]
        private string _sceneName = "default";

        [SerializeField]
        private GoalTarget[] _targets;

        public void OnEnable()
        {
            SceneManager.activeSceneChanged += OnSceneChanged;
        }

        public void OnDisable()
        {
            SceneManager.activeSceneChanged -= OnSceneChanged;
        }

        public void OnSceneChanged(Scene scene, Scene scene1)
        {
            
        }
    }
}