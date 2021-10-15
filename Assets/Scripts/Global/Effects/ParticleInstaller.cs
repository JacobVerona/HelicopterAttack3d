using HelicopterAttack.Global;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public abstract class ParticleInstaller<TEvent, TData> : MonoBehaviour
        where TEvent : GlobalEvent<TData>
    {
        [SerializeField]
        private TEvent _event;

        [SerializeField]
        protected ParticleSystem Particles;

        private void OnEnable()
        {
            _event.AddListener(Handler);
        }

        private void OnDisable()
        {
            _event.RemoveListener(Handler);
        }

        protected abstract void Handler(TData data);
    }
}


