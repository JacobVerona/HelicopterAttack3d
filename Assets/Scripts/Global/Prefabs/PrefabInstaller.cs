using System.Collections.Generic;
using UnityEngine;

namespace HelicopterAttack.Global
{
    public record Person
    {

    }

    public sealed class PrefabInstaller : MonoBehaviour
    {
        [SerializeField]
        private List<ComponentInstaller> _componentInstallers;

        [SerializeField]
        private GameObject _prefab;

        public GameObject Install(Vector3 position, Quaternion quaternion, Transform parent)
        {
            var gameObject = Instantiate(_prefab, position, quaternion, parent);
            _componentInstallers.ForEach(inst => inst.Install(gameObject));

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


