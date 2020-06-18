using System;

namespace FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();

                switch (item)
                {
                    case "hoodie": budget -= 30; break;
                    case "keychain": budget -= 4; break;
                    case "T-shirt": budget -= 20; break;
                    case "flag": budget -= 15; break;
                    case "sticker": budget -= 1; break;
                    default: break;
                }
            }

            if (budget >= 0)
                Console.WriteLine($"You bought {n} items and left with {budget} lv.");
            else
            {
                budget = Math.Abs(budget);
                Console.WriteLine($"Not enough money, you need {budget} more lv.");
            }
        }
    }
}
