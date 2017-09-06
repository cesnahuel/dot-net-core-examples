using System.Collections.Generic;


namespace CommandPattern
{
    public class User<T>
    {
        private ICalculator<T> _calculator;
        private LinkedList<ICommand> _commands;
        public User()
        {
            _calculator = new Calculator<T>();
            _commands = new LinkedList<ICommand>();
        }
    }
}
