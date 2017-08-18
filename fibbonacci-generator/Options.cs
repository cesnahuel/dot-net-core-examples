using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;


namespace Fibonacci
{
    class Options
    {
        [Option('s', "start", Default = 0u, HelpText = "Start the Fibonacci sequence from.")]
        public uint Start { get; set; }

        [Option('c', "count", Default = 100u, HelpText = "Number of Fibbonacci numbers to show.")]
        public uint Count { get; set; }
    }
}
