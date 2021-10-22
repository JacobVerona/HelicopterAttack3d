using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public class RadarMarker : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _markerPrefab;

        [SerializeField]
        protected Radar Radar;

        public RadarMarker Constructor(Radar radar)
        {
            Radar = radar;
            return this;
        }

        private void Awake()
        {
            Radar.Register(this);
        }

        private void OnEnable()
        {
            Radar.SetMarkerActive(this, true);
        }

        private void OnDisable()
        {
            Radar.SetMarkerActive(this, false);
        }

        private void OnDestroy()
        {
            Radar.Unregister(this);
        }

        public virtual RectTransform CreateMarker(RectTransform markersArea)
        {
            return Instantiate(_markerPrefab, markersArea);
        }

        public virtual Vector2 GetMarkerPositionOnRadar()
        {
            return Radar.WorldPositionToRadarPosition(transform.position);
        }
    }
}
