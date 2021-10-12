using HelicopterAttack.RPG;
using HelicopterAttack.Characters.General.Groups;

namespace HelicopterAttack.Characters
{
    public struct Damage
    {
        public CharacterGroup Owner;
        public float Value;

        public void Deal(CharacterAttribute attribute)
        {
            attribute.AddValue(-Value, CharacterAttribute.ValueModifier.Base);
        }
    }
}