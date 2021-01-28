using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int rounds = int.Parse(Console.ReadLine());
            double points = 0.00d;

            double d1 = 0;
            double d2 = 0;
            double d3 = 0;
            double d4 = 0;
            double d5 = 0;
            double invalidNumbers = 0;

            for (int i = 0; i < rounds; i++)
            {
                int interval = int.Parse(Console.ReadLine());

                if (interval >= 0 && interval <= 9)
                {
                    points += interval * 0.20;
                    d1++;
                }
                else if (interval >= 10 && interval <= 19)
                {
                    points += interval * 0.30;
                    d2++;
                }
                else if (interval >= 20 && interval <= 29)
                {
                    points += interval * 0.40;
                    d3++;
                }
                else if (interval >= 30 && interval <= 39)
                {
                    points += 50;
                    d4++;
                }
                else if (interval >= 40 && interval <= 50)
                {
                    points += 100;
                    d5++;
                }
                else
                {
                    points = points / 2;
                    invalidNumbers++;
                }
            }

            double p1 = (d1 / rounds) * 100;
            double p2 = (d2 / rounds) * 100;
            double p3 = (d3 / rounds) * 100;
            double p4 = (d4 / rounds) * 100;
            double p5 = (d5 / rounds) * 100;
            double p6 = (invalidNumbers / rounds) * 100;

            Console.WriteLine($"{points:F2}");
            Console.WriteLine($"From 0 to 9: {p1:F2}%");
            Console.WriteLine($"From 10 to 19: {p2:F2}%");
            Console.WriteLine($"From 20 to 29: {p3:F2}%");
            Console.WriteLine($"From 30 to 39: {p4:F2}%");
            Console.WriteLine($"From 40 to 50: {p5:F2}%");
            Console.WriteLine($"Invalid numbers: {p6:F2}%");
        }
    }
}
