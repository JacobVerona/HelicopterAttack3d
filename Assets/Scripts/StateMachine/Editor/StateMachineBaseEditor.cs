using UnityEditor;
using UnityEngine;

namespace HelicopterAttack.StateMachine.Editor
{
    [CustomEditor(typeof(StateMachine), true)]
    public class StateMachineBaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI ()
        {

            var stateMachine = ((StateMachine)target);

            foreach (var state in stateMachine.StateTypes)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(state.Name);
                GUILayout.EndHorizontal();
            }
            base.OnInspectorGUI();
        }
    }
}

