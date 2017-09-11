namespace CommandPattern
{
    public class DoubleFactory : GenericFactory<double>, INumericFactory<double>
    {
        public DoubleFactory()
        {
        }
        public INode<double> GetAddOperation(INode<double> first, INode<double> second)
        {
            DoubleMethod<double> add = new DoubleMethod<double>(Operation.ADD, (double one, double two) => one + two);
            return new Operation<double>(add, first, second);
        }
        public INode<double> GetSubtractOperation(INode<double> first, INode<double> second)
        {
            DoubleMethod<double> substract = new DoubleMethod<double>(Operation.SUBTRACT, (double one, double two) => one - two);
            return new Operation<double>(substract, first, second);
        }
        public INode<double> GetMultiplyOperation(INode<double> first, INode<double> second)
        {
            DoubleMethod<double> multiply = new DoubleMethod<double>(Operation.MULTIPLY, (double one, double two) => one * two);
            return new Operation<double>(multiply, first, second);
        }
        public INode<double> GetDivideOperation(INode<double> first, INode<double> second)
        {
            DoubleMethod<double> divide = new DoubleMethod<double>(Operation.DIVIDE, (double one, double two) => one / two);
            return new Operation<double>(divide, first, second);
        }
    }

    public static class DoubleFactoryExtentions
    {
        public static INode<double> GetAddOperation(this IFactory<double> factory, INode<double> first, INode<double> second)
        {
            return (factory as DoubleFactory).GetAddOperation(first, second);
        }
    }
}
