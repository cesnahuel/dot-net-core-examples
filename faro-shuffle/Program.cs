using System;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingDesk =
                from s in Card.Suits()
                from r in Card.Ranks()
                select new { Suit = s, Rank = r };

            foreach(var c in startingDesk)
            {
                Console.WriteLine($"{c.Suit} {c.Rank}");
            }
        }
    }
}
