using UnityEngine;
using UnityEngine.UI;

namespace HelicopterAttack.UI.HUD
{
    public class RadarMarker : MonoBehaviour
    {
        [SerializeField]
        private Image _markerImagePrefab;

        [SerializeField]
        protected Radar Radar;

        private RectTransform _markerGraphicRect;

        public void Constuctor(Radar radar)
        {
            Radar?.Unregister(this);

            Radar = radar;

            Radar.Register(this);
        }

        private void Awake()
        {
            Radar?.Register(this);
        }

        private void OnEnable()
        {
            _markerGraphicRect?.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _markerGraphicRect?.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Radar.Unregister(this);
        }

        public virtual RectTransform CreateMarker(RectTransform _markersArea)
        {
            _markerGraphicRect = Instantiate(_markerImagePrefab, _markersArea).rectTransform;
            return _markerGraphicRect;
        }

        public virtual void RadarUIUpdate(in RectTransform markerGraphic)
        {
            markerGraphic.anchoredPosition = Radar.WorldPositionToRadarPosition(transform.position);
        }
    }
}
