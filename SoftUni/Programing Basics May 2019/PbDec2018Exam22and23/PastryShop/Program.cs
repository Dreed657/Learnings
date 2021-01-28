using System;

namespace PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string dessert = Console.ReadLine();
            int orderedCakes = int.Parse(Console.ReadLine());
            int dayOfTheMonth = int.Parse(Console.ReadLine());
            double sum = 0;

            if (dayOfTheMonth <= 15)
            {
                switch (dessert)
                {
                    case "Cake": sum = orderedCakes * 24; break;
                    case "Souffle": sum = orderedCakes * 6.66; break;
                    case "Baklava": sum = orderedCakes * 12.60; break;
                    default: break;
                }
            }
            else
            {
                switch (dessert)
                {
                    case "Cake": sum = orderedCakes * 28.70; break;
                    case "Souffle": sum = orderedCakes * 9.80; break;
                    case "Baklava": sum = orderedCakes * 16.98; break;
                    default: break;
                }
            }

            if (!(dayOfTheMonth > 22))
            {
                if (sum >= 100 && sum < 200)
                {
                    sum -= sum * 0.15;
                }
                else if (sum >= 200)
                {
                    sum -= sum * 0.25;
                }
            }

            if (dayOfTheMonth <= 15)
            {
                sum -= sum * 0.10;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
