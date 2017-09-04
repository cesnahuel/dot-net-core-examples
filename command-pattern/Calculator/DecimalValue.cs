namespace CommandPattern
{
    class DecimalValue : INode<decimal>
    {
        decimal _value;
        public DecimalValue(decimal @value)
        {
            _value = @value;
        }

        public override decimal Compute()
        {
            return _value;
        }

        public override string ToString()
        {
            return $"{_value:0.3}";
        }

    }
}
