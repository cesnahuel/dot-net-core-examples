using System;


namespace CommandPattern
{
    public class SingleOperation<T> : INode<T>
    {
        protected INode<T> _right;
        private SingleMethod<T> _method;
        public SingleOperation(SingleMethod<T> method)
        {
            _method = method;
        }
        public SingleOperation(INode<T> right)
        {
            _right = right;
        }
        public SingleOperation(SingleMethod<T> method, INode<T> right) : this(right)
        {
            _method = method;
        }
        public virtual T Compute()
        {
            return _method.Call(_right.Compute());
        }
        public override string ToString()
        {
            return _method.ToString($"{_right}");
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
