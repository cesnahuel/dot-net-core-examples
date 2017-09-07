using System;
using System.Linq;


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
        public Operation(INode<T> left, INode<T> right)
        {
            _left = left;
            _right = right;
        }
        public Operation(INode<T> left, INode<T> right, string operand) : this(left, right)
        {
            _operand = operand;
        }
        public abstract T Compute();
        public override string ToString()
        {
            string [] multiplyOrDivide = { "*", "/" };
            string left = $"{_left}";
            string right = $"{_right}";
            if (multiplyOrDivide.Any(o => o == _operand))
            {
                string [] addOrSubstract = { "+", "-" };
                if (addOrSubstract.Any(o => o == (_left as Operation<T>)?._operand))
                {
                    left = $"[{_left}]";
                }
                if (addOrSubstract.Any(o => o == (_right as Operation<T>)?._operand))
                {
                    right = $"[{_right}]";
                }

            }
            return $"{left} {_operand} {right}";
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
