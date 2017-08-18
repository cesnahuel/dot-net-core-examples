using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using CommandLine;


namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = Parser.Default.ParseArguments<Options>(args);
            parser.MapResult(
                (Options opts) => DisplayFibonacchiNumbers(opts),
                error => 1
            );
        }

        static int DisplayFibonacchiNumbers(Options opts)
        {
            Console.WriteLine($"Generate {opts.Count} Fibonacci values:");
            var generator = new FibonacciGenerator();
            IEnumerable<BigInteger> fibRange = generator.Generate(opts.Start + opts.Count)
                .Skip(Convert.ToInt32(opts.Start));

            foreach (BigInteger digit in fibRange)
            {
                Console.Write($"{digit} ");
            }
            Console.Write(System.Environment.NewLine);
            return 0;
        }
    }
}
