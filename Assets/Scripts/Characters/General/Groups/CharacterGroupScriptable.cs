using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Groups
{
    [CreateAssetMenu(fileName = "New character group", menuName = "Characters/Groups/Group")]
    public class CharacterGroupScriptable : ScriptableObject
    {
        [SerializeField]
        private string Name;

        [SerializeField]
        private Relation[] _relations = new Relation[0];

        private Dictionary<CharacterGroupScriptable, Relation> _relationsMap
            = new Dictionary<CharacterGroupScriptable, Relation>();

        public void Init ()
        {
            _relationsMap.Clear();
            for (int i = 0; i < _relations.Length; i++)
            {
                _relationsMap.Add(_relations[i].SecondGroup, _relations[i]);
            }
        }

        private void OnEnable ()
        {
            Init();
        }

#if UNITY_EDITOR
        private void OnValidate ()
        {
            Init();
        }
#endif

        public bool IsAggressive (CharacterGroupScriptable secondGroup)
        {
            return RelationType(secondGroup) == Relation.RelationType.Aggressive;
        }

        public bool IsFriendly (CharacterGroupScriptable secondGroup)
        {
            return RelationType(secondGroup) == Relation.RelationType.Friendly;
        }

        public bool IsNormal (CharacterGroupScriptable secondGroup)
        {
            return RelationType(secondGroup) == Relation.RelationType.Normal;
        }

        public Relation.RelationType RelationType (CharacterGroupScriptable secondGroup)
        {
            if (_relationsMap.TryGetValue(secondGroup, out Relation relation))
            {
                return relation.Type;
            }
            else
            {
                return Relation.RelationType.Normal;
            }
        }

        [System.Serializable]
        public class Relation
        {
            public enum RelationType
            {
                Friendly,
                Normal,
                Aggressive
            }

            public CharacterGroupScriptable SecondGroup;
            public RelationType Type;
        }
    }
}
