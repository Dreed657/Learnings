using System;

namespace _02._Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double d = r * 180 / Math.PI;
            Math.Round(d);

            Console.WriteLine($"{d:F0}");
        }
    }
}
