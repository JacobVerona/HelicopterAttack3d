using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public class GoalMarker : RadarMarker
    {
        public override void RadarUIUpdate(in RectTransform markerGraphic)
        {
            markerGraphic.anchoredPosition = Radar.WorldPositionToRadarPositionClamped(transform.position);
        }
    }
}
