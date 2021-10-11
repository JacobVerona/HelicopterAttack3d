using Cinemachine;
using System.Collections;
using UnityEngine;

namespace HelicopterAttack.Characters
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraFXShake : MonoBehaviour
    {
        private CinemachineBasicMultiChannelPerlin _perlin;

        [SerializeField]
        private float _amplitudeGainPower = 5f;

        [SerializeField]
        private float _normalizedSpeed = 10f;

        private void Awake()
        {
            _perlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Shake()
        {
            StopCoroutine(nameof(ShakeCoroutine));
            StartCoroutine(nameof(ShakeCoroutine));
        }

        private IEnumerator ShakeCoroutine()
        {
            _perlin.m_AmplitudeGain = _amplitudeGainPower;
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
