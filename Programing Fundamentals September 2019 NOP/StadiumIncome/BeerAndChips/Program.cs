using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFootballFan = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int bottesBeer = int.Parse(Console.ReadLine());
            int bagsOfChips = int.Parse(Console.ReadLine());
            double moneyLeft = 0;

            double beerPrice = bottesBeer * 1.20;
            double chipsPrice = Math.Ceiling((beerPrice * 0.45) * bagsOfChips);
            double moneySpend = beerPrice + chipsPrice;
            double money = Math.Round(moneySpend, 2);

            if (moneySpend >= budget)
            {
                moneyLeft = Math.Abs(moneySpend - budget);
                Console.WriteLine($"{nameFootballFan} needs {moneyLeft:F2} more leva!");
            }
            else
            {
                moneyLeft = Math.Abs(budget - moneySpend);
                Console.WriteLine($"{nameFootballFan} bought a snack and has {moneyLeft:F2} leva left.");
            }
        }
    }
}
