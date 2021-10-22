using System;
using UnityEngine;

namespace HelicopterAttack.Global
{
    public abstract class ComponentInstaller<T> : ComponentInstaller
        where T : MonoBehaviour
    {
        public override void Install(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out T component))
            {
                Resolve(component);
            }
            else
            {
                Debug.LogException(new NullReferenceException("The given prefab does not have a required component for installer"));
            }
        }

        public abstract void Resolve(in T component);
    }

    public abstract class ComponentInstaller : MonoBehaviour
    {
        public abstract void Install(GameObject gameObject);
    }
}


