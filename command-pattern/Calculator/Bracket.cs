namespace CommandPattern
{
    class Bracket<T> : INode<T>
    {
        private INode<T> _node;
        public Bracket(INode<T> node)
        {
            _node = node;
        }
        public override T Compute()
        {
            return _node.Compute();
        }
        public override string ToString()
        {
            return $"({_node})";
        }
        public INode<T> Node
        {
            get
            {
                return _node;
            }

            set
            {
                _node = value;
            }
        }
    }
}
