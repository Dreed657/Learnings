using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int candyMakerCount = int.Parse(Console.ReadLine());
            int cakeCount = int.Parse(Console.ReadLine());
            int waffleCount = int.Parse(Console.ReadLine());
            int crapesCount = int.Parse(Console.ReadLine());

            int cakePrice = 45;
            double wafflePrice = 5.80;
            double crapePrice = 3.20;

            double cakeSum = cakeCount * cakePrice;
            double waffleSum = waffleCount * wafflePrice;
            double crapeSum = crapesCount * crapePrice;

            double expensePerDay = (cakeSum + waffleSum + crapeSum) * candyMakerCount;
            double allTheMoney = expensePerDay * days;
            double ratio = allTheMoney / 8;

            double moneyGathered = allTheMoney - ratio;

            Console.WriteLine($"{moneyGathered:F2}");
        }
    }
}
