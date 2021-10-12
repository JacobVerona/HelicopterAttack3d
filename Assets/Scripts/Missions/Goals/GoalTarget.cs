using System;
using UnityEngine;

namespace HelicopterAttack.Missions
{
    public abstract class GoalTarget : MonoBehaviour
    {
        public abstract event Action<GoalTarget> Completed;
    }
}
