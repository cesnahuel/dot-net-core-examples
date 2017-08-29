using System;
using System.Text;
using System.Linq;


namespace FaroShuffle
{
    class Program
    {
        static void Main()
        {
            var startingDeck = (
                from s in Card.Suits()
                from r in Card.Ranks()
                select new Card(s, r)
            ).ToArray();
            /*
            var startingDeck = (
                from s in Card.Suits().LogQuery("Suit Generation")
                from r in Card.Ranks().LogQuery("Rank Generation")
                select new Card(s, r)
            ).LogQuery("Starting deck");
            */
            foreach(var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            int repeats = 0;
            var shuffle = startingDeck;
            do
            {
                shuffle = shuffle.Skip(26).InterleaveSequenceWith(shuffle.Take(26)).ToArray();
                /*
                shuffle = shuffle.Skip(26)
                    .LogQuery("Bottom Half")
                    .InterleaveSequenceWith(
                        shuffle.Take(26).LogQuery("Top half")
                    ).LogQuery("Shuffle");
                */
                Console.WriteLine(string.Concat(Enumerable.Repeat("=", 20)));
                foreach(var c in shuffle)
                {
                    Console.WriteLine(c);
                }
                repeats++;
            } while (!shuffle.SequenceEqual(startingDeck));

            Console.WriteLine(new StringBuilder().Insert(0, "-", 20));
            Console.WriteLine($"shuffled {repeats} times.");
        }
    }
}
