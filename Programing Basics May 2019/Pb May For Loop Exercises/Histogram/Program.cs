using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double d1 = 0;
            double d2 = 0;
            double d3 = 0;
            double d4 = 0;
            double d5 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                    d1++;
                else if (num >= 200 && num < 400)
                    d2++;
                else if (num >= 400 && num < 600)
                    d3++;
                else if (num >= 600 && num < 800)
                    d4++;
                else if (num >= 800)
                    d5++;
            }

            double p1 = (d1 / n) * 100; 
            double p2 = (d2 / n) * 100; 
            double p3 = (d3 / n) * 100; 
            double p4 = (d4 / n) * 100; 
            double p5 = (d5 / n) * 100;

            Console.WriteLine($"{p1:F2}%\n{p2:F2}%\n{p3:F2}%\n{p4:F2}%\n{p5:F2}%");
        }
    }
}
