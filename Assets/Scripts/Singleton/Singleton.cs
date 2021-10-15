using UnityEngine;

namespace HelicopterAttack.Singleton
{
    public abstract class Singleton<T> : Singleton
        where T : MonoBehaviour
    {
        private static T _instance;

        private static readonly object _lock = new object();

        private bool _persistent = true;

        public static T Instance 
        { 
            get
            {
                if (Quitting)
                {
                    Debug.LogError($"[{nameof(Singleton)}<{typeof(T)}>] Instance will not be returned because tha application is quitted");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance != null)
                    {
                        return _instance;
                    }

                    var instances = FindObjectsOfType<T>();
                    var count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                        {
                            return _instance = instances[0];
                        }

                        Debug.LogError($"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one gameObject with that component");
                        for (int i = 1; i < instances.Length; i++)
                        {
                            Destroy(instances[i]);
                        }
                        return instances[0];
                    }

                    Debug.LogError($"[{nameof(Singleton)}<{typeof(T)}>] An instance is needed in the scene, it was created");
                    return _instance = new GameObject($"({nameof(Singleton)}){typeof(T)}")
                        .AddComponent<T>();
                }
            } 
        }

        public virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            if (_persistent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    public abstract class Singleton : MonoBehaviour
    {
        public static bool Quitting { get; private set; }

        private void OnApplicationQuit()
        {
            Quitting = true;
        }
    }
}
