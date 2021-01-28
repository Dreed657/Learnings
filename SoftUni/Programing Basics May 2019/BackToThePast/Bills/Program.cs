using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int mounts = int.Parse(Console.ReadLine());

            double electricBills = 0;
            double waterBills = 0;
            double internetBills = 0;

            for (int i = 0; i < mounts; i++)
            {
                double bill = double.Parse(Console.ReadLine());
                electricBills += bill;
                waterBills += 20;
                internetBills += 15;
            }

            double otherBills = electricBills + waterBills + internetBills;
            otherBills += otherBills * 0.20;
            double averageBill = (electricBills + waterBills + internetBills + otherBills) / mounts;

            Console.WriteLine($"Electricity: {electricBills:F2} lv");
            Console.WriteLine($"Water: {waterBills:F2} lv");
            Console.WriteLine($"Internet: {internetBills:F2} lv");
            Console.WriteLine($"Other: {otherBills:F2} lv");
            Console.WriteLine($"Average: {averageBill:F2} lv");
        }
    }
}
