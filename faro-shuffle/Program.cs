using System;
using System.Text;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static void Main()
        {
            var startingDesk = (
                from s in Card.Suits()
                from r in Card.Ranks()
                select new Card(s, r)
            ).ToArray();

            foreach(var c in startingDesk)
            {
                Console.WriteLine(c);
            }

            int repeats = 0;
            var shuffle = startingDesk;
            do
            {
                shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26)).ToArray();

                Console.WriteLine(string.Concat(Enumerable.Repeat("=", 20)));
                foreach(var c in shuffle)
                {
                    Console.WriteLine(c);
                }
                repeats++;
            } while (!shuffle.SequenceEqual(startingDesk));

            Console.WriteLine(new StringBuilder().Insert(0, "-", 20));
            Console.WriteLine($"shuffled {repeats} times.");
        }
    }
}
