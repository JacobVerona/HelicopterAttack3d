namespace HelicopterAttack.RPG
{
    public class CharacterAttribute
    {
        public enum ValueModifier
        {
            Base = 0, Add = 1, Percent = 2
        }

        public event System.Action<float> ValueChanged;

        private float[] _values = new float[3];

        public CharacterAttribute (float value)
        {
            _values[(int)ValueModifier.Base] = value;
        }

        public void AddValue (float value, ValueModifier modifier)
        {
            _values[(int)modifier] += value;
            ValueChanged?.Invoke(Value);
        }

        public void RemoveValue (float value, ValueModifier modifier)
        {
            _values[(int)modifier] -= value;
            ValueChanged?.Invoke(Value);
        }

        public float BaseValue
        {
            get => _values[(int)ValueModifier.Base];
        }

        public float AddedValue
        {
            get => _values[(int)ValueModifier.Add];
        }

        public float PercentValue
        {
            get => _values[(int)ValueModifier.Percent];
        }

        public float Value
        {
            get
            {
                var baseAdded = _values[(int)ValueModifier.Base] + _values[(int)ValueModifier.Add];
                var percent = _values[(int)ValueModifier.Percent] / 100f;
                return baseAdded + (baseAdded * percent);
            }
        }
    }
}