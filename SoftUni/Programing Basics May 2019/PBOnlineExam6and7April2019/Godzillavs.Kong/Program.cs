using System;

namespace Godzillavs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double pricePerExtraClouting = double.Parse(Console.ReadLine());

            double priceDecor = filmBudget * .10;

            if (extrasCount > 150)
                pricePerExtraClouting -= pricePerExtraClouting * .10;

            double priceForClouts = pricePerExtraClouting * extrasCount;

            double sum = priceDecor + priceForClouts;

            if (filmBudget >= sum)
            {
                double moneyLeft = filmBudget - sum;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
            }
            else
            {
                double moneyLeft = sum - filmBudget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyLeft:F2} leva more.");
            }
        }
    }
}
