namespace CommandPattern
{
    public class MultiplyOperation<T> : Operation<T> where T : INumeric<T>
    {
        public MultiplyOperation() : base("*")
        {
        }
        public MultiplyOperation(INode<T> left, INode<T> right) : base(left, right, "*")
        {
        }
        public override T Compute()
        {
            return _left.Compute().Multiply(_right.Compute());
        }
    }
}
