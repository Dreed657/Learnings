using System;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyQuota = int.Parse(Console.ReadLine());

            int fishCount = 0;
            int realFishCount = 0;
            double income = 0;
            double expenses = 0;

            while (true)
            {
                string typeFish = Console.ReadLine();
                if (typeFish == "Stop")
                    break;

                double fishWeight = double.Parse(Console.ReadLine());
                double fishPrice = 0.00d;

                foreach (char letter in typeFish)
                    fishPrice += letter;

                fishPrice = fishPrice / fishWeight;
                fishCount++;

                if (fishCount == 3)
                {
                    income += fishPrice;
                    fishCount = 0;
                }
                else
                    expenses += fishPrice;

                realFishCount++;

                if (realFishCount >= dailyQuota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
            }

            double money = income - expenses;

            if (money > 0)
            {
                Console.WriteLine($"Lyubo's profit from {realFishCount} fishes is {Math.Abs(money):F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(money):F2} leva today.");
            }
        }
    }
}
