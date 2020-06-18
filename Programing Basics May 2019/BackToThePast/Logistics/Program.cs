using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double totalWeight = 0;
            double withBus = 0;
            double withTruck = 0;
            double withTrain = 0;

            for (int i = 0; i < n; i++)
            {
                int loadWeight = int.Parse(Console.ReadLine());
                totalWeight += loadWeight;

                if (loadWeight <= 3)
                    withBus += loadWeight;
                else if (loadWeight >= 4 && loadWeight <= 11)
                    withTruck += loadWeight;
                else if (loadWeight >= 12)
                    withTrain += loadWeight;
            }
            
            double averageWeight = (withBus * 200 + withTruck * 175 + withTrain * 120) / totalWeight;

            double pWithBus = (withBus / totalWeight) * 100;
            double pwithTruck = (withTruck / totalWeight) * 100;
            double pwithTrain = (withTrain / totalWeight) * 100;

            Console.WriteLine($"{averageWeight:F2}");
            Console.WriteLine($"{pWithBus:F2}%");
            Console.WriteLine($"{pwithTruck:F2}%");
            Console.WriteLine($"{pwithTrain:F2}%");
        }
    }
}
