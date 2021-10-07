using UnityEditor;
using UnityEngine;

namespace Characters.StateMachine.Editor
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

                if (GUILayout.Button("Switch state"))
                {
                    stateMachine.SetState(state);
                }
                GUILayout.EndHorizontal();
            }

            base.OnInspectorGUI();
        }

    }
}

