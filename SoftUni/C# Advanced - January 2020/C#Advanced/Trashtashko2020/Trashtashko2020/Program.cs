using System;

namespace Trashtashko2020
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = double.Parse(Console.ReadLine());
            double expences = double.Parse(Console.ReadLine());
            double incs = double.Parse(Console.ReadLine());
            double priceCar = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            double totalMoney = salary;

            for (int i = 0; i < n - 1; i++)
            {
                salary = salary + incs;
                totalMoney += salary;
            }

            double totalExpences = expences * n;
            totalMoney -= totalExpences;
            
            Console.WriteLine(totalMoney >= priceCar ? "Have a nice ride!" : "Work harder!");
        }
    }
}
