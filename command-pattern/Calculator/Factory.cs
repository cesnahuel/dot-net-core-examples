using System;


namespace CommandPattern
{
    public interface IFactory<T>
    {
        INode<T> GetValue(T value);
    }

    public interface INumericFactory<T> : IFactory<T>
    {
        INode<T> GetAddOperation(INode<T> first, INode<T> second);
        INode<T> GetSubtractOperation(INode<T> first, INode<T> second);
        INode<T> GetMultiplyOperation(INode<T> first, INode<T> second);
        INode<T> GetDivideOperation(INode<T> first, INode<T> second);
    }

    public interface IMethod
    {
        Operation Operation { get; set; }
    }
    public interface ISingleMethod<T> : IMethod
    {
        T Call(T first);
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

    public class GenericFactory<T> : IFactory<T> where T : new()
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
}
