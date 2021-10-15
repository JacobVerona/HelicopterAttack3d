using Cinemachine;
using HelicopterAttack.Global;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    [RequireComponent(typeof(CameraFXShake),
        typeof(CinemachineVirtualCamera))]
    public class ExplosionShake : MonoBehaviour
    {
        [SerializeField]
        private List<SpaceFloatEvent> _shakeEvents;

        [SerializeField]
        private float _distanceNormalize = 1f;

        private CameraFXShake _shakeFX;
        private CinemachineComponentBase _cinemachineBase;

        private void Awake()
        {
            _shakeFX = GetComponent<CameraFXShake>();
            _cinemachineBase = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComponentBase>();
        }

        private void OnEnable()
        {
            _shakeEvents.ForEach(e => e.AddListener(OnExplosion));
        }

        private void OnDisable()
        {
            _shakeEvents.ForEach(e => e.RemoveListener(OnExplosion));
        }

        private void OnExplosion(SpaceEventData data)
        {
            _shakeFX.Shake(data.parameter 
                / (Vector3.Distance(_cinemachineBase.FollowTarget.position, data.position) 
                * _distanceNormalize));
        }
    }
}
