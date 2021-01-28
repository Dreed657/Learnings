using System;

namespace TripFurlConsumtion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distance:");
            double kilometers = double.Parse(Console.ReadLine());
            Console.WriteLine("What is your fuel consumtion:");
            double fuelComsumtion = double.Parse(Console.ReadLine());
            Console.WriteLine("Fuel price:");
            double fuelPrice = double.Parse(Console.ReadLine());
            //Console.WriteLine("Units");
            //string units = Console.ReadLine();

            double amountLiters = 0;
            double money = 0;

            amountLiters = (kilometers / 100) * fuelComsumtion;
            money = amountLiters * fuelPrice;

            Console.WriteLine($"Litters needed:{amountLiters:F2}");
            Console.WriteLine($"Total costs for fuel will be {money:F2}");
        }
    }
}
