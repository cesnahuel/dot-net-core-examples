namespace CommandPattern
{
    class Value<T> : INode<T>
    {
        private T _value;
        public Value(T value)
        {
            _value = value;
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
