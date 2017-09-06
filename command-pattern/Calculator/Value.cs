namespace CommandPattern
{
    class Value<T> : INode<T>
    {
        private T _value;
        public Value(T value)
        {
            _value = value;
        }
        // Set default value in default constructor
        public Value()
        {
            _value = default(T);
        }
        public T Compute()
        {
            return _value;
        }
        public override string ToString()
        {
            return $"{_value}";
        }
    }
}
