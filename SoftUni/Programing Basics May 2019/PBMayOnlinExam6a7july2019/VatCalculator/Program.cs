using System;

namespace VatCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            double vatRate = double.Parse(Console.ReadLine());

            double vatPrice = price / (1 + (vatRate / 100));

            Console.WriteLine($"{vatPrice:f2}");
        }
    }
}
