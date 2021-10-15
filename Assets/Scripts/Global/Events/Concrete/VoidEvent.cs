using System;
using UnityEngine;

namespace HelicopterAttack.Global
{
    [CreateAssetMenu(fileName = "Void event", menuName = "Global/Events/Void")]
    public class VoidEvent : GlobalEvent<Void>
    {
        public static readonly Void Void = new Void();

        public void Invoke()
        {
            Invoke(Void);
        }
    }
}
