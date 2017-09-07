using System;


namespace CommandPattern
{
    public class AddOperation<T> : Operation<T> where T : INumericAdd<T>
    {
        public AddOperation() : base(Operation.ADD)
        {
        }
        public AddOperation(INode<T> left, INode<T> right) : base(left, right, Operation.ADD)
        {
        }
        public override T Compute()
        {
            return _left.Compute().Add(_right.Compute());
        }
    }
}
