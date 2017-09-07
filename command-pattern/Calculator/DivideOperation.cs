namespace CommandPattern
{
    public class DivideOperation<T> : Operation<T> where T : INumeric<T>
    {
        public DivideOperation() : base(Operation.DIVIDE)
        {
        }

        public override T Compute()
        {
            return _left.Compute().Divide(_right.Compute());
        }
    }

}
