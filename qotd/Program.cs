using System;
using System.IO;
using System.Threading.Tasks;


namespace QotD
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Error.WriteLineAsync("You must specify a quotes file.");
                Console.ResetColor();
                return 1;
            }

            string[] quotes = await File.ReadAllLinesAsync(args[0]);
            string randomQuote = quotes[new Random().Next(0, quotes.Length - 1)];
            await Console.Out.WriteLineAsync($"[QOTD]: {randomQuote}");

            return 0;
        }
    }
}
