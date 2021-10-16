using HelicopterAttack.Characters.General.Combat;
using UnityEngine;

namespace HelicopterAttack.Characters.Helicopter
{
    public class PlayerCrosshair : MonoBehaviour
    {
        [SerializeField]
        private CharacterAim _aim;

        private void Update()
        {
            if (_aim.IsTargetVisible() == false)
            {
                transform.position = Camera.main.WorldToScreenPoint(_aim.transform.position);
            }
            else
            {
                transform.position = Camera.main.WorldToScreenPoint(_aim.GetTargetPosition());
            }
        }


    }
}
