using System;

namespace _03._Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double c = double.Parse(Console.ReadLine());

            double temp = c * 1.8 + 32;

            Console.WriteLine($"{temp:F2}");
        }
    }
}
