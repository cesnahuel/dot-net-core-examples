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

    public interface ITrigonometryFactory<T> : IFactory<T>
    {
        INode<T> GetSinOperation(INode<T> first);
        INode<T> GetCosOperation(INode<T> first);
    }

    public interface IFunctionFactory<T> : IFactory<T>
    {
        INode<T> GetPow2Operation(INode<T> first);
        INode<T> GetPowOperation(INode<T> first, INode<T> second);
    }

    public interface IMethod
    {
        Operation Operation { get; set; }
    }
    public interface ISingleMethod<T> : IMethod
    {
        T Call(T first);
        string ToString(string first);
    }
    public interface IDoubleMethod<T> : IMethod
    {
        T Call(T first, T second);
        string ToString(string first, string second);
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
        /*
        public override string ToString()
        {
            return _operation.ToString(true);
        }*/
        public string ToString(string first, string second)
        {
            return _operation.Representation(first, second);
        }
    }
    public class SingleMethod<T> : ISingleMethod<T>
    {
        private Operation _operation;
        private Func<T, T> _method;
        public SingleMethod(Operation operation, Func<T, T> method)
        {
            _operation = operation;
            _method = method;
        }
        public T Call(T first) => _method(first);
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
        /*
        public override string ToString()
        {
            return _operation.ToString(true);
        }*/
        public string ToString(string first)
        {
            return _operation.Representation(first);
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
