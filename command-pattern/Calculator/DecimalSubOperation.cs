namespace CommandPattern
{
    public class DecimalSubOperation : Operation<decimal>
    {
        public DecimalSubOperation() : base("-")
        {
        }

        public override decimal Compute()
        {
            return _left.Compute() - _right.Compute();
        }
    }
}
