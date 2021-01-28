using System;

namespace OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            double hualRent = double.Parse(Console.ReadLine());

            double priceStatues = hualRent - (hualRent * .30);
            double priceFood = priceStatues - (priceStatues * .15);
            double priceSound = priceFood / 2;

            double sum = hualRent + priceStatues + priceFood + priceSound;
            Console.WriteLine($"{sum:F2}");
        }
    }
}
