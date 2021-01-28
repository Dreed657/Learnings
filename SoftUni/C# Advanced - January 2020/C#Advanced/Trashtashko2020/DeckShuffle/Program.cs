using System;

namespace DeckShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int cardsMax = int.Parse(Console.ReadLine());
            var splitIndex = Console.ReadLine().Split();

            var cards = new int[cardsMax];

            for (int i = 0; i < cardsMax; i++) cards[i] = i;
        }
    }
}
