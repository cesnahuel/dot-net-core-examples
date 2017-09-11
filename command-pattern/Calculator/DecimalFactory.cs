namespace CommandPattern
{
    public class DecimalFactory : GenericFactory<decimal>, INumericFactory<decimal>
    {
        public DecimalFactory()
        {
        }
        public INode<decimal> GetAddOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> add = new DoubleMethod<decimal>(Operation.ADD, (decimal one, decimal two) => one + two);
            return new Operation<decimal>(add, first, second);
        }
        public INode<decimal> GetSubtractOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> substract = new DoubleMethod<decimal>(Operation.SUBTRACT, (decimal one, decimal two) => one - two);
            return new Operation<decimal>(substract, first, second);
        }
        public INode<decimal> GetMultiplyOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> multiply = new DoubleMethod<decimal>(Operation.MULTIPLY, (decimal one, decimal two) => one * two);
            return new Operation<decimal>(multiply, first, second);
        }
        public INode<decimal> GetDivideOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> divide = new DoubleMethod<decimal>(Operation.DIVIDE, (decimal one, decimal two) => one / two);
            return new Operation<decimal>(divide, first, second);
        }
    }
}
