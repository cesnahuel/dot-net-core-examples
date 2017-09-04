namespace CommandPattern
{
    public class DecimalMultOperation : Operation<decimal>
    {
        public DecimalMultOperation() : base("*")
        {
        }

        public override decimal Compute()
        {
            return _left.Compute() * _right.Compute();
        }
    }
}
