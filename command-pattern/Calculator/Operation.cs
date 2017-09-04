namespace CommandPattern
{
    public abstract class Operation<T> : INode<T>
    {
        protected INode<T> _left;
        protected INode<T> _right;
        private string _operand;
        public Operation(string operand)
        {
            _operand = operand;
        }
        public override abstract T Compute();
        public override string ToString()
        {
            return $"{_left} {_operand} {_right}";
        }
    }
}
