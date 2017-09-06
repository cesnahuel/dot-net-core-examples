namespace CommandPattern
{
    class Calculator<T> : ICalculator<T>
    {
        private INode<T> _node;
        public Calculator()
        {
        }
        public T Compute()
        {
            return _node.Compute();
        }
        public void Operation(INode<T> node)
        {
            _node = node;
        }
    }
}
