namespace CommandPattern
{
    class CalculatorCommnad<T> : ICommand
    {
        private char _operator;
        private int _operand;
        private ICalculator<T> _calculator;
        public CalculatorCommnad(ICalculator<T> calculator, char @operator, int operand)
        {
            _calculator = calculator;
            _operator = @operator;
            _operand = operand;
        }

        public void Execute()
        {
        }

        public void UnExecute()
        {
        }
    }
}
