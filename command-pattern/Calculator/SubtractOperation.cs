namespace CommandPattern
{
    public class SubtractOperation<T> : Operation<T> where T : INumeric<T>
    {
        public SubtractOperation() : base("-")
        {
        }
        public SubtractOperation(INode<T> left, INode<T> right) : base(left, right, "-")
        {
        }
        public override T Compute()
        {
            return _left.Compute().Subtract(_right.Compute());
        }
    }
}
