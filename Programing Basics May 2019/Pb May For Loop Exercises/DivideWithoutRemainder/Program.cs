using System;

namespace DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double d1 = 0;
            double d2 = 0;
            double d3 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                    d1++;
                if (num % 3 == 0)
                    d2++;
                if (num % 4 == 0)
                    d3++;
            }

            double p1 = (d1 / n) * 100;
            double p2 = (d2 / n) * 100;
            double p3 = (d3 / n) * 100;

            Console.WriteLine($"{p1:F2}%\n{p2:F2}%\n{p3:F2}%");
        }
    }
}
