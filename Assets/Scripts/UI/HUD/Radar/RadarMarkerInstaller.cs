using HelicopterAttack.Global;
using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public class RadarMarkerInstaller : ComponentInstaller<RadarMarker>
    {
        [SerializeField]
        private Radar _radar;

        public override void Resolve(in RadarMarker component)
        {
            component.Constructor(_radar);
        }
    }
}
