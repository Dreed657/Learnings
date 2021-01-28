using System;

namespace PBMaySampleExam30June
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodMoney = int.Parse(Console.ReadLine());
            double souvenirsMoney = int.Parse(Console.ReadLine());
            double hotelMoney = int.Parse(Console.ReadLine());

            double distanceToSea = 210 * 2;
            double fuelConsumtion = distanceToSea / 100 * 7;
            double fuelPrice = fuelConsumtion * 1.85;
            double acomentaction = 3 * foodMoney + 3 * souvenirsMoney;

            double firstDay = hotelMoney - (hotelMoney * 0.10);
            double secondDay = hotelMoney - (hotelMoney * 0.15);
            double therthDay = hotelMoney - (hotelMoney * 0.20);

            double total = fuelPrice + acomentaction + firstDay + secondDay + therthDay;

            Console.WriteLine($"Money needed: {total:F2}");
        }
    }
}
