namespace CommandPattern
{
    public class DecimalAddOperation : Operation<decimal>
    {
        public DecimalAddOperation() : base("+")
        {
        }

        public override decimal Compute()
        {
            return _left.Compute() + _right.Compute();
        }
    }
}
