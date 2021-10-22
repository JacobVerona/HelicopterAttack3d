using UnityEngine;

namespace HelicopterAttack.Global
{
    public struct SpaceEventData
    {
        public readonly Vector3 position;
        public readonly float parameter;

        public SpaceEventData(Vector3 position, float parameter)
        {
            this.position = position;
            this.parameter = parameter;
        }
    }
}
