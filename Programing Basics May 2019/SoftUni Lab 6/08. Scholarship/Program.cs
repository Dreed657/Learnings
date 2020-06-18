using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double incomeLeva = double.Parse(Console.ReadLine());
            double averageGDA = double.Parse(Console.ReadLine());
            double minimulSalary = double.Parse(Console.ReadLine());
            double scholarShipAmount = 0.0;

            if (incomeLeva < minimulSalary)
            {
                if (averageGDA > 4.5)
                {
                    scholarShipAmount = minimulSalary * 0.35;
                    Math.Floor(scholarShipAmount);
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarShipAmount)} BGN");
                }
            }
            else if (averageGDA > 5.5)
            {
                scholarShipAmount = averageGDA * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarShipAmount)} BGN");
            }
            else
                Console.WriteLine($"You cannot get a scholarship!");
        }
    }
}