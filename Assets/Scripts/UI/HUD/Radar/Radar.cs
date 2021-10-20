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

        private void FixedUpdate()
        {
            foreach (var marker in _markers)
            {
                if (marker.Key.enabled == false) return;

                marker.Value.anchoredPosition = marker.Key.GetMarkerPositionOnRadar();
            }
        }
        private void OnDestroy()
        {
            _markers.Clear();
        }

        public void Register(RadarMarker marker)
        {
            if (_markers.ContainsKey(marker) == true)
            {
                Debug.LogWarning("Marker is already registered in the radar");
                return;
            }

            _markers.Add(marker, marker.CreateMarker(_markersArea));
        }

        public void Unregister(RadarMarker marker)
        {
            if (_markers.ContainsKey(marker) == false)
                return;

            Destroy(_markers[marker].gameObject);
            _markers.Remove(marker);
        }

        public void SetMarkerActive(RadarMarker marker, bool activeState)
        {
            if(_markers.TryGetValue(marker, out RectTransform rect))
            {
                rect.gameObject.SetActive(activeState);
            }
        }

        public Vector2 WorldPositionToRadarPosition(Vector3 position)
        {
            return RectTransfromUtilityExtention
                .WorldPositionToRectLocalPosition(_player.transform.position, position, _scale);
        }

        public Vector2 WorldPositionToRadarPositionClamped(Vector3 position)
        {
            return RectTransfromUtilityExtention
                .WorldPositionToRectLocalPositionClampedInRect(_player.transform.position, position, _markersArea.rect, _scale);
        }
    }
}
