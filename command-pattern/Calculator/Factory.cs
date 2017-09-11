using System;


namespace CommandPattern
{
    public interface IFactory<T>
    {
        INode<T> GetValue(T value);
    }

    public interface IMethod
    {
        Operation Operation { get; set; }
    }
    public interface ISingleMethod<T> : IMethod
    {
        T Method(T first);
    }
    public interface IDoubleMethod<T> : IMethod
    {
        T Call(T first, T second);
    }

    public class DoubleMethod<T> : IDoubleMethod<T>
    {
        private Operation _operation;
        private Func<T, T, T> _method;
        public DoubleMethod(Operation operation, Func<T, T, T> method)
        {
            _operation = operation;
            _method = method;
        }
        public T Call(T first, T second) => _method(first, second);
        public Operation Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
            }
        }
        public override string ToString()
        {
            return _operation.ToString(true);
        }
    }

    public class GenericFactory<T> : IFactory<T>
    {
        public GenericFactory()
        {
        }
        public INode<T> GetValue(T value)
        {
            INode<T> valueNode = new Value<T>(value);
            return valueNode;
        }
    }

    public class DecimalFactory : GenericFactory<decimal>
    {
        public DecimalFactory()
        {
        }
        public INode<decimal> GetAddOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> add = new DoubleMethod<decimal>(Operation.ADD, (decimal one, decimal two) => one + two);
            return new Operation<decimal>(add, first, second);
        }
        public INode<decimal> GetSubstractOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> substract = new DoubleMethod<decimal>(Operation.SUBTRACT, (decimal one, decimal two) => one - two);
            return new Operation<decimal>(substract, first, second);
        }
        public INode<decimal> GetMultiplyOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> multiply = new DoubleMethod<decimal>(Operation.MULTIPLY, (decimal one, decimal two) => one * two);
            return new Operation<decimal>(multiply, first, second);
        }
        public INode<decimal> GetDiviveOperation(INode<decimal> first, INode<decimal> second)
        {
            DoubleMethod<decimal> divide = new DoubleMethod<decimal>(Operation.DIVIDE, (decimal one, decimal two) => one / two);
            return new Operation<decimal>(divide, first, second);
        }
    }
}
