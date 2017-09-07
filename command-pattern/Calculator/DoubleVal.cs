namespace CommandPattern
{
    public struct DoubleVal : INumeric<DoubleVal>
    {
        private double _value;
        public DoubleVal(double value)
        {
            _value = value;
        }
        static public implicit operator DoubleVal(double value)
        {
            return new DoubleVal(value);
        }
        public DoubleVal Add(DoubleVal that)
        {
            _value += that._value;
            return this;
        }
        public DoubleVal Subtract(DoubleVal that)
        {
            _value -= that._value;
            return this;
        }
        public DoubleVal Multiply(DoubleVal that)
        {
            _value *= that._value;
            return this;
        }
        public DoubleVal Divide(DoubleVal that)
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
