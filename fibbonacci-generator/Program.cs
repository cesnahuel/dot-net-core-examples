using System;
using System.Numerics;


namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            uint number = 100;
            Console.WriteLine($"Generate first {number} Fibonacci values:");
            var generator = new FibonacciGenerator();
            foreach (BigInteger digit in generator.Generate(number))
            {
                Console.Write($"{digit} ");
            }
            Console.Write(System.Environment.NewLine);
        }
    }
}
