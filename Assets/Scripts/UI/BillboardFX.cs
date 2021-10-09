using UnityEngine;

namespace HelicopterAttack.UI
{
    [RequireComponent(typeof(Canvas))]
    public class BillboardFX : MonoBehaviour
    {
        [SerializeField]
        private Quaternion _originalRotation;

        private void Awake()
        {
            _originalRotation = transform.rotation;
        }

        private void LateUpdate()
        {
            transform.rotation = Camera.main.transform.rotation * _originalRotation;
        }
    }
}