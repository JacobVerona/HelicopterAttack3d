using HelicopterAttack.Global;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.UI.HUD
{
    public sealed class Radar : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _markersArea;

        [SerializeField]
        private Transform _player;

        [SerializeField]
        private float _scale = 1f;

        private Dictionary<RadarMarker, RectTransform> _markers = new Dictionary<RadarMarker, RectTransform>();

        private void Update()
        {
            foreach (var marker in _markers)
            {
                marker.Key.RadarUIUpdate(marker.Value);
            }
        }

        public Vector2 WorldPositionToRadarPosition(Vector3 position)
        {
            var pos = position - _player.transform.position;
            return pos.ToVector2XZ() * _scale;
        }

        public Vector2 WorldPositionToRadarPositionClamped(Vector3 position)
        {
            var pos = position - _player.transform.position;

            var resultPosition = pos.ToVector2XZ() * _scale;
            resultPosition = new Vector2(Mathf.Clamp(resultPosition.x, _markersArea.rect.min.x, _markersArea.rect.max.x),
                Mathf.Clamp(resultPosition.y, _markersArea.rect.min.y, _markersArea.rect.max.y));
            return resultPosition;
        }

        public void Register(RadarMarker marker)
        {
            _markers.Add(marker, marker.CreateMarker(_markersArea));
        }

        public void Unregister(RadarMarker marker)
        {
            if (_markers.TryGetValue(marker, out RectTransform rectTransform))
            {
                _markers.Remove(marker);
                Destroy(rectTransform.gameObject);
            }
        }
    }
}
