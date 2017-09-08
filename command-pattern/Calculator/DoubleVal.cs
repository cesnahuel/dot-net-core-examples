using System;


namespace CommandPattern
{
    public struct DoubleVal : INumeric<DoubleVal>, ITrigonometry<DoubleVal>
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
        public static implicit operator double(DoubleVal digit)
        {
            return digit._value;
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

    public static class TrigonometryExtentions
    {
        public static DoubleVal Sin(this ITrigonometry<DoubleVal> value)
        {
            return Math.Sin((DoubleVal)value);
        }
    }
}
