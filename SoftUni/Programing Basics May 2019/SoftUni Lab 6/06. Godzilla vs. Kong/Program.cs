using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetFilm = double.Parse(Console.ReadLine());
            double stuntManCount = double.Parse(Console.ReadLine());
            double bomberManDressPrice = double.Parse(Console.ReadLine());

            double decorBudget = budgetFilm * 0.10;

            if (stuntManCount >= 150)
                bomberManDressPrice = bomberManDressPrice - (bomberManDressPrice * 0.10);

            double productionCosts = (stuntManCount * bomberManDressPrice) + decorBudget;

            double budgetLeft = 0.0;

            if (productionCosts <= budgetFilm)
            {
                budgetLeft = budgetFilm - productionCosts;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetLeft:F2} leva left.");
            }
            else
            {
                budgetLeft = productionCosts - budgetFilm;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {budgetLeft:F2} leva more.");
            }
        }
    }
}
