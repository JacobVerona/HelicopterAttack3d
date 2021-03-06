using System;
using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Global
{
    public sealed class PrefabInstaller : MonoBehaviour
    {
        public event System.Action<GameObject> Created;

        [SerializeField]
        private List<ComponentInstaller> _componentInstallers;

        [SerializeField]
        private GameObject _prefab;

        public GameObject Install(Vector3 position, Quaternion quaternion, Transform parent)
        {
            bool activeState = _prefab.activeSelf;

            _prefab.SetActive(false);

            var gameObject = Instantiate(_prefab, position, quaternion, parent);
            _componentInstallers.ForEach(inst => inst.Install(gameObject));
            Created?.Invoke(gameObject);

            gameObject.SetActive(activeState);

            _prefab.SetActive(activeState);

            return gameObject;
        }

        public GameObject Install(Vector3 position, Transform parent)
        {
            return Install(position, Quaternion.identity, parent);
        }
        
        public GameObject Install(Vector3 position)
        {
            return Install(position, Quaternion.identity, transform);
        }

        public GameObject Install()
        {
            return Install(_prefab.transform.position, _prefab.transform.rotation, transform);
        }
    }
}


