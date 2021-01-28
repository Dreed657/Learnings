using System;

namespace Task_001
{
    class Program
    {
        static void Main(string[] args)
        {
            int coverNeeded = int.Parse(Console.ReadLine());
            int paintNeeded = int.Parse(Console.ReadLine());
            int spacerNeeded = int.Parse(Console.ReadLine());
            int timeWorkersNeded = int.Parse(Console.ReadLine());

            double moneyCover = (coverNeeded + 2) * 1.50;
            double moneyPaint = (paintNeeded + (paintNeeded * .10)) * 14.50;
            double moneySpacer = spacerNeeded * 5.00;

            double moneySupplies = moneyCover + moneyPaint + moneySpacer + .40;
            double workerPayCheck = moneySupplies * .30;

            double totalExpences = moneySupplies + (workerPayCheck * timeWorkersNeded);

            Console.WriteLine($"Total expenses: {totalExpences:F2} lv.");
        }
    }
}
