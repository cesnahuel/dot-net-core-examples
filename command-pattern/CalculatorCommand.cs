namespace CommandPattern
{
    class CalculatorCommnad : ICommand
    {
        private char _operator;
        private int _operand;
        private ICalculator _calculator;
        public CalculatorCommnad(Calculator calculator, char @operator, int operand)
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
