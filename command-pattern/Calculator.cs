namespace CommandPattern
{
    class Calculator<T> : ICalculator<T>
    {
        private INode<T> _operation;
        public Calculator()
        {
            // initialize default value
            _operation = new Value<T>();
        }
        public T Compute()
        {
            return _operation.Compute();
        }
        public override string ToString()
        {
            return _operation.ToString();
        }
        public INode<T> SetOperation(INode<T> operation)
        {
            INode<T> previous = _operation;
            _operation = operation;
            return previous;
        }
        public INode<T> CurrentOperation
        {
            get
            {
                return _operation;
            }
        }
    }
}
