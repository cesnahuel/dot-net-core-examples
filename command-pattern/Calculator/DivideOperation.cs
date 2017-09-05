namespace CommandPattern
{
    public class DivideOperation<T> : Operation<T> where T : INumeric<T>
    {
        public DivideOperation() : base("/")
        {
        }

        public override T Compute()
        {
            return _left.Compute().Divide(_right.Compute());
        }
    }

}
