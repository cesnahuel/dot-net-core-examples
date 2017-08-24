using System;
using System.Collections.Generic;


namespace FaroShuffle
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public Card(Suit s, Rank r)
        {
            Suit = s;
            Rank = r;
        }
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
        public static IEnumerable<Suit> Suits() => Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>;
        public static IEnumerable<Rank> Ranks() => Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>;
    }
}
