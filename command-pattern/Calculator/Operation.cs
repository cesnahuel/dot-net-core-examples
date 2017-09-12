using System;
using System.Linq;


namespace CommandPattern
{
    public class Operation<T> : INode<T>
    {
        protected INode<T> _left;
        protected INode<T> _right;
        private DoubleMethod<T> _method;
        public Operation(DoubleMethod<T> method)
        {
            _method = method;
        }
        public Operation(INode<T> left, INode<T> right)
        {
            _left = left;
            _right = right;
        }
        public Operation(DoubleMethod<T> method, INode<T> left, INode<T> right) : this(left, right)
        {
            _method = method;
        }
        public T Compute()
        {
            return _method.Call(_left.Compute(), _right.Compute());
        }
        public override string ToString()
        {
            Operation [] multiplyOrDivide = { Operation.MULTIPLY, Operation.DIVIDE };
            string left = $"{_left}";
            string right = $"{_right}";
            if (multiplyOrDivide.Any(o => o == _method.Operation))
            {
                Operation [] addOrSubstract = { Operation.ADD, Operation.SUBTRACT };
                if (addOrSubstract.Any(o => o == (_left as Operation<T>)?._method.Operation))
                {
                    left = $"[{_left}]";
                }
                if (addOrSubstract.Any(o => o == (_right as Operation<T>)?._method.Operation))
                {
                    right = $"[{_right}]";
                }

            }
            return _method.ToString(left, right);
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
