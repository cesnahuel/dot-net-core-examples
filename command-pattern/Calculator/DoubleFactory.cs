using System;


namespace CommandPattern
{
    public class DoubleFactory : GenericFactory<double>, INumericFactory<double>, ITrigonometryFactory<double>, IFunctionFactory<double>
    {
        private static DoubleFactory _factory = null;
        private DoubleFactory()
        {
        }
        public static DoubleFactory GetInstance()
        {
            if (_factory == null)
            {
                _factory = new DoubleFactory();
            }
            return _factory;
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
        public INode<double> GetSinOperation(INode<double> first)
        {
            SingleMethod<double> sin = new SingleMethod<double>(Operation.SIN, (double one) => Math.Sin(one));
            return new SingleOperation<double>(sin, first);
        }
        public INode<double> GetCosOperation(INode<double> first)
        {
            SingleMethod<double> cos = new SingleMethod<double>(Operation.COS, (double one) => Math.Cos(one));
            return new SingleOperation<double>(cos, first);
        }
        public INode<double> GetPow2Operation(INode<double> first)
        {
            SingleMethod<double> pow2 = new SingleMethod<double>(Operation.POW2, (double one) => Math.Pow(one, 2.0));
            return new SingleOperation<double>(pow2, first);
        }
        public INode<double> GetPowOperation(INode<double> first, INode<double> second)
        {
            DoubleMethod<double> pow = new DoubleMethod<double>(Operation.POW, (double one, double two) => Math.Pow(one, two));
            return new Operation<double>(pow, first, second);
        }
    }
}
