using System;

namespace CommandPattern
{
    public class Operation<T> : INode<T>
    {
        protected INode<T> _left;
        protected INode<T> _right;
        private string _operand;
        public Operation(string operand)
        {
            _operand = operand;
        }
        public Operation(INode<T> left, INode<T> right)
        {
            _left = left;
            _right = right;
        }
        public Operation(INode<T> left, INode<T> right, string operand) : this(left, right)
        {
            _operand = operand;
        }
        public override T Compute() => throw new NotSupportedException();
        public override string ToString()
        {
            return $"{_left} {_operand} {_right}";
        }
        public INode<T> LeftNode
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
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
