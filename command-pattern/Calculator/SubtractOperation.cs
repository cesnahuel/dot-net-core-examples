namespace CommandPattern
{
    public class SubtractOperation<T> : Operation<T> where T : INumeric<T>
    {
        public SubtractOperation() : base(Operation.SUBTRACT)
        {
        }
        public SubtractOperation(INode<T> left, INode<T> right) : base(left, right, Operation.SUBTRACT)
        {
        }
        public override T Compute()
        {
            return _left.Compute().Subtract(_right.Compute());
        }
    }
}
