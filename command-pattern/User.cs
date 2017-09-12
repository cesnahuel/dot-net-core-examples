using System.Collections.Generic;
using System;


namespace CommandPattern
{
    public enum Operation
    {
        ADD, SUBTRACT, MULTIPLY, DIVIDE, SIN, COS, SQRT, POW, POW2
    }
    public static class OperationExtention
    {
        private static string[] names = { "+", "-", "*", "/", "sin", "cos", "sqrt", "pow", "pow2" };
        private static string[] formats = { "{0} + {1}", " {0} - {1}", " {0} * {1}", "{0} / {1}", "sin({0})", "cos({0})", "sqrt({0})", "({0})^{1}", "({0})^2" };
        /*
        public static string ToString(this Operation operation, bool @switch)
        {
            if (@switch)
            {
                return names[(int)operation];
            }
            return $"{operation}";
        }
        */
        public static string Representation(this Operation operation, string first)
        {
            return String.Format(formats[(int)operation], first);
        }
        public static string Representation(this Operation operation, string first, string second)
        {
            return String.Format(formats[(int)operation], first, second);
        }
    }
    public class User<T> where T : new()
    {
        private ICalculator<T> _calculator;
        private uint _level;
        private LinkedList<ICommand> _history;
        private IFactory<T> _factory;
        public User(IFactory<T> factory)
        {
            _calculator = new Calculator<T>();
            _history = new LinkedList<ICommand>();
            _level = 0;
            _factory = factory;
        }
        public void SetValue(T value)
        {
            INode<T> operation = new Value<T>(value);
            ICommand command = new CalculatorCommnad<T>(_calculator, operation);
            command.Execute();
            _level++;
            _history.AddLast(command);
        }
        public void Apply(Operation operation, INode<T> right)
        {
            INode<T> node = null;
            switch(operation)
            {
                case Operation.ADD:
                    node = (_factory as INumericFactory<T>)?.GetAddOperation(_calculator.CurrentOperation, right);
                    break;
                case Operation.MULTIPLY:
                    node = (_factory as INumericFactory<T>)?.GetMultiplyOperation(_calculator.CurrentOperation, right);
                    break;
                case Operation.DIVIDE:
                    node = (_factory as INumericFactory<T>)?.GetDivideOperation(_calculator.CurrentOperation, right);
                    break;
                case Operation.SUBTRACT:
                    node = (_factory as INumericFactory<T>)?.GetSubtractOperation(_calculator.CurrentOperation, right);
                    break;
                case Operation.SIN:
                    node = (_factory as ITrigonometryFactory<T>)?.GetSinOperation(_calculator.CurrentOperation);
                    break;
            }
            if (node == null)
            {
                throw new NotImplementedException($"No suitable implementation found for '{operation}' in the factory");
            }
            ICommand command = new CalculatorCommnad<T>(_calculator, node);
            command.Execute();
            _level++;
            _history.AddLast(command);
        }
        public void Apply(Operation operation, T right)
        {
            INode<T> value = new Value<T>(right);
            Apply(operation, value);
        }
        public void Apply(Operation operation)
        {
            INode<T> node = null;
            switch(operation)
            {
                case Operation.SIN:
                    node = (_factory as ITrigonometryFactory<T>)?.GetSinOperation(_calculator.CurrentOperation);
                    break;
                case Operation.COS:
                    node = (_factory as ITrigonometryFactory<T>)?.GetCosOperation(_calculator.CurrentOperation);
                    break;
            }
            if (node == null)
            {
                throw new NotImplementedException($"No suitable implementation found for '{operation}' in the factory");
            }
            ICommand command = new CalculatorCommnad<T>(_calculator, node);
            command.Execute();
            _level++;
            _history.AddLast(command);
        }
    }
}
