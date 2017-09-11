using System.Collections.Generic;


namespace CommandPattern
{
    public enum Operation
    {
        ADD,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
        SIN,
        COS,
        SQRT,
        POW
    }
    public static class OperationExtention
    {
        public static string ToString(this Operation operation, bool @switch)
        {
            if (@switch)
            {
                string [] names = { "+", "-", "*", "/", "sin", "cos", "sqrt", "pow" };
                return names[(int)operation];
            }
            return $"{operation}";
        }
    }
    public class User<T> where T : INumeric<T>
    {
        private ICalculator<T> _calculator;
        private uint _level;
        private LinkedList<ICommand> _history;
        public User()
        {
            _calculator = new Calculator<T>();
            _history = new LinkedList<ICommand>();
            _level = 0;
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
            Operation<T> node = null;
            switch(operation)
            {
                case Operation.ADD:
                    break;
                case Operation.MULTIPLY:
                    break;
                case Operation.DIVIDE:
                    break;
                case Operation.SUBTRACT:
                    break;
            }
            node.LeftNode = _calculator.CurrentOperation;
            node.RightNode = right;
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
    }
}
