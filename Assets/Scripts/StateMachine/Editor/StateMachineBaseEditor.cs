using UnityEditor;
using UnityEngine;

namespace HelicopterAttack.StateMachine.Editor
{
    [CustomEditor(typeof(StateMachineBase), true)]
    public class StateMachineBaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI ()
        {

            var stateMachine = ((StateMachineBase)target);

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

