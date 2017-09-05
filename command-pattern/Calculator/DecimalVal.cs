
namespace CommandPattern
{
    public struct DecimalVal : INumeric<DecimalVal>
    {
        private decimal _value;
        public DecimalVal(decimal value)
        {
            _value = value;
        }
        static public implicit operator DecimalVal(decimal value)
        {
            return new DecimalVal(value);
        }
        public DecimalVal Add(DecimalVal that)
        {
            _value += that._value;
            return this;
        }
        public DecimalVal Subtract(DecimalVal that)
        {
            _value -= that._value;
            return this;
        }
        public DecimalVal Multiply(DecimalVal that)
        {
            _value *= that._value;
            return this;
        }
        public DecimalVal Divide(DecimalVal that)
        {
            _value /= that._value;
            return this;
        }
        public override string ToString()
        {
            return $"{_value}";
        }
    }
}
