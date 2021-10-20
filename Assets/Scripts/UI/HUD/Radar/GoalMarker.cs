using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public class GoalMarker : RadarMarker
    {
        public override Vector2 GetMarkerPositionOnRadar()
        {
            return Radar.WorldPositionToRadarPositionClamped(transform.position);
        }
    }
}
