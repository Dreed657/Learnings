using System;

namespace Task_002
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuCount = int.Parse(Console.ReadLine());
            int cpuCount = int.Parse(Console.ReadLine());
            int ramSticksCount = int.Parse(Console.ReadLine());

            double totalPriceGpu = gpuCount * 250;
            double totalPriceCpu = (totalPriceGpu * .35) * cpuCount;
            double totalPriceRam = (totalPriceGpu * .10) * ramSticksCount;

            double totalMoney = totalPriceCpu + totalPriceGpu + totalPriceRam;

            if (gpuCount > cpuCount)
                totalMoney -= totalMoney * .15;

            if (budget >= totalMoney)
            {
                double moneyNeeded = budget - totalMoney;
                Console.WriteLine($"You have {moneyNeeded:F2} leva left!");
            }
            else
            {
                double moneyNeeded = totalMoney - budget;
                Console.WriteLine($"Not enough money! You need {moneyNeeded:F2} leva more!");
            }

        }
    }
}
