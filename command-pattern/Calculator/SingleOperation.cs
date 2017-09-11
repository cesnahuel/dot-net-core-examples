using System;


namespace CommandPattern
{
    public class SingleOperation<T> : INode<T>
    {
        protected INode<T> _right;
        protected Operation _operand;
        private Func<T, T> _method;
        public SingleOperation(Operation operand)
        {
            _operand = operand;
        }
        public SingleOperation(Func<T, T> method, Operation operand)
        {
            _operand = operand;
            _method = method;
        }
        public SingleOperation(INode<T> right)
        {
            _right = right;
        }
        public SingleOperation(Func<T, T> method, Operation operand, INode<T> right) : this(right)
        {
            _operand = operand;
            _method = method;
        }
        public virtual T Compute()
        {
            return _method(_right.Compute());
        }
        public override string ToString()
        {
            return $"{_operand.ToString(true)}({_right})";
        }
        public INode<T> RightNode
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }
    }
}
