namespace CommandPattern
{
    public struct DecimalVal : INumeric<DecimalVal>
    {
        private decimal _value;
        //public DecimalVal() : this(0)
        //{}
        public DecimalVal(decimal value)
        {
            _value = value;
        }
        static public implicit operator DecimalVal(decimal value)
        {
            return new DecimalVal(value);
        }
        static public implicit operator decimal(DecimalVal digit)
        {
            return digit._value;
        }
        public DecimalVal Add(DecimalVal that)
        {
            return decimal.Add(this, that);
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
