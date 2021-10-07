using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Groups
{
    [RequireComponent(typeof(Collider))]
    public class CharacterGroup : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        [SerializeField] private CharacterGroupScriptable _group;

        public Bounds Bounds => _collider.bounds;

        public bool IsAggressive (CharacterGroup other) => _group.IsAggressive(other._group);
        public bool IsFiendly (CharacterGroup other) => _group.IsFriendly(other._group);
        public bool IsNormal (CharacterGroup other) => _group.IsNormal(other._group);
    }
}
