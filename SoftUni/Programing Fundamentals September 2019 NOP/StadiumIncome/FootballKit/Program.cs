using System;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerT = double.Parse(Console.ReadLine());
            double moneyNeeded = double.Parse(Console.ReadLine());

            double pantsPrice = pricePerT * 0.75;
            double socksPrice = pantsPrice * 0.20;
            double shoePrice = (pricePerT + pantsPrice) * 2;

            double money = pricePerT + pantsPrice + socksPrice + shoePrice;
            money -= money * 0.15;

            if (money >= moneyNeeded)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {money:F2} lv.");
            }
            else
            {
                double diff = moneyNeeded - money;
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {diff:F2} lv. more.");
            }
        }
    }
}
