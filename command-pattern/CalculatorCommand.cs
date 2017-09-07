using System;


namespace CommandPattern
{
    class CalculatorCommnad<T> : ICommand
    {
        private INode<T> _newOperation;
        private INode<T> _oldOperation;
        private ICalculator<T> _calculator;
        public CalculatorCommnad(ICalculator<T> calculator, INode<T> operation)
        {
            _calculator = calculator;
            _newOperation = operation;
            _oldOperation = _calculator.CurrentOperation;
        }
        public void Execute()
        {
            ShowCalculation(_newOperation);
        }
        public void UnExecute()
        {
            ShowCalculation(_oldOperation);
        }
        private void ShowCalculation(INode<T> operation)
        {
            _calculator.SetOperation(operation);
            Console.WriteLine($"expression '{_calculator}' evaluation {_calculator.Compute()}");
        }
    }
}
