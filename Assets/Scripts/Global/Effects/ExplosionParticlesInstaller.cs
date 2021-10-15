using HelicopterAttack.Global;
using UnityEngine;

namespace HelicopterAttack.Characters.General.Combat
{
    public class ExplosionParticlesInstaller : ParticleInstaller<SpaceFloatEvent, SpaceEventData>
    {
        public void CreateExlposionParticles(Vector3 position, float power)
        {
            Instantiate(Particles, position, Quaternion.identity)
                .transform.localScale = Vector3.one * power;
        }

        protected override void Handler(SpaceEventData data)
        {
            CreateExlposionParticles(data.position, data.parameter);
        }
    }
}


