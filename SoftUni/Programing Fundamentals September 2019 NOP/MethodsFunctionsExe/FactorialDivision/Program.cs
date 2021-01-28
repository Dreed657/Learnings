using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());

            double result = Factorial(n1) / Factorial(n2);

            Console.WriteLine($"{result:F2}");
        }

        static double Factorial(double i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
