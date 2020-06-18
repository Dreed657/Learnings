using System;

namespace SoftUni_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double result = n * 1.79549;
            Math.Round(result);

            Console.WriteLine($"{result:F2}");
        }
    }
}
