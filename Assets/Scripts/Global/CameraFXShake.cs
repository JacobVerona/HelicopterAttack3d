using Cinemachine;
using HelicopterAttack.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraFXShake : MonoBehaviour
    {
        private CinemachineBasicMultiChannelPerlin _perlin;

        [SerializeField]
        private List<SpaceFloatEvent> _shakeEvents;

        [SerializeField]
        private float _amplitudeGainPower = 5f;

        [SerializeField]
        private float _normalizedSpeed = 10f;

        private IEnumerator _coroutine;

        private void Awake()
        {
            _perlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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
            Shake(data.parameter);
        }

        public void Shake(float power)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = ShakeCoroutine(power);
            StartCoroutine(_coroutine);
        }

        private IEnumerator ShakeCoroutine(float power)
        {
            _perlin.m_AmplitudeGain = power;
            yield return new WaitUntil(() =>
            {
                _perlin.m_AmplitudeGain = Mathf.Lerp(_perlin.m_AmplitudeGain, 0, Time.deltaTime * _normalizedSpeed);

                if (_perlin.m_AmplitudeGain < 0.05f)
                {
                    _perlin.m_AmplitudeGain = 0f;
                    return true;
                }
                return false;
            });
        }
    }
}
