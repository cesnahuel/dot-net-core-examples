using System;
using System.Linq;


namespace CommandPattern
{
    public abstract class SingleOperation<T> : INode<T>
    {
        protected INode<T> _right;
        protected Operation _operand;
        public SingleOperation(Operation operand)
        {
            _operand = operand;
        }
        public SingleOperation(INode<T> right)
        {
            _right = right;
        }
        public SingleOperation(INode<T> right, Operation operand) : this(right)
        {
            _operand = operand;
        }
        public abstract T Compute();
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
