using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermanCount = int.Parse(Console.ReadLine());
            double totalPrice = 0.0d;
            double moneyLeft = 0.0d;

            if (season == "Spring")
                totalPrice += 3000;
            else if (season == "Summer")
                totalPrice += 4200;
            else if (season == "Winter")
                totalPrice += 2600;
            else if (season == "Autumn")
                totalPrice += groupBudget;

            if (fishermanCount <= 6)
                totalPrice -= totalPrice * 0.10;
            else if (fishermanCount >= 7 && fishermanCount <= 11)
                totalPrice -= totalPrice * 0.15;
            else if (fishermanCount > 12)
                totalPrice -= totalPrice * 0.25;

            if (fishermanCount % 2 == 0)
            {
                if (season != "Autumn")
                    totalPrice -= totalPrice * 0.05;
            }

            if (groupBudget >= totalPrice)
            {
                moneyLeft = groupBudget - totalPrice;
                Console.WriteLine($"Yes! You have {Math.Abs(moneyLeft):F2} leva left.");
            }
            else
            {
                moneyLeft = totalPrice - groupBudget;
                Console.WriteLine($"Not enough money! You need {Math.Abs(moneyLeft):F2} leva.");
            }
        }
    }
}
