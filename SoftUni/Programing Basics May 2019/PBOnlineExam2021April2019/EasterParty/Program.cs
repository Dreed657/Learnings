using System;

namespace EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            double kovertPrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (guestsCount >= 10 && guestsCount <= 15)
                kovertPrice -= kovertPrice * .15;
            else if (guestsCount > 15 && guestsCount <= 20)
                kovertPrice -= kovertPrice * .20;
            else if (guestsCount > 20)
                kovertPrice -= kovertPrice * .25;

            double cakePrice = .10 * budget;
            double moneyNeeded = (guestsCount * kovertPrice) + cakePrice;

            if (moneyNeeded <= budget)
            {
                double moneyLeft = budget - moneyNeeded;
                Console.WriteLine($"It is party time! {moneyLeft:F2} leva left.");
            }
            else
            {
                double moneyLeft = moneyNeeded - budget;
                Console.WriteLine($"No party! {moneyLeft:F2} leva needed.");
            }
        }
    }
}
