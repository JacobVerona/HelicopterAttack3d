using System;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public abstract class TargetGoal : MonoBehaviour
    {
        public abstract event Action<TargetGoal> Completed;

        public abstract string Description { get; }
    }
}
