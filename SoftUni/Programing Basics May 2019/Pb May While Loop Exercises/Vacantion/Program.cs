using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            int dayCounter = 0;
            int spendCounter = 0;

            while (budget < moneyNeeded && spendCounter < 5)
            {
                string action = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());

                switch (action)
                {
                    case "save":
                        spendCounter = 0;
                        budget += amount;
                        break;
                    case "spend":
                        budget -= amount;
                        if (budget < 0)
                        {
                            budget = 0;
                        }
                        spendCounter++;
                        break;
                }
                dayCounter++;
            }
            if (spendCounter == 5)
            {
                Console.WriteLine($"You can't save the money.\n{dayCounter}");
            }
            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {dayCounter} days.");
            }
        }
    }
}
