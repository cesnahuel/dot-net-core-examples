namespace CommandPattern
{
    public class DecimalDivOperation : Operation<decimal>
    {
        public DecimalDivOperation() : base("/")
        {
        }

        public override decimal Compute()
        {
            return _left.Compute() + _right.Compute();
        }
    }
}
