using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriqPrice = double.Parse(Console.ReadLine());
            double cacaPrice = double.Parse(Console.ReadLine());
            double palamudQuantity = double.Parse(Console.ReadLine());
            double safridQuantity = double.Parse(Console.ReadLine());
            double midiQuantity = double.Parse(Console.ReadLine());

            double palamudPrice = skumriqPrice + (0.6 * skumriqPrice);
            double safridPrice = cacaPrice + (0.8 * cacaPrice);
            double midiPrice = 7.50;

            double palamudSum = palamudQuantity * palamudPrice;
            double safridSum = safridQuantity * safridPrice;
            double midiSum = midiQuantity * midiPrice;

            double fullSum = palamudSum + safridSum + midiSum;

            Console.WriteLine($"{fullSum:F2}");
        }
    }
}
