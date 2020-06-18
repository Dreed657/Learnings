using System;

namespace SoftUni_Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            string weather = "unknown";

            if (n >= 26.00 & n <= 35.00)
            {
                weather = "Hot";
            }
            if (n >= 20.1 & n <= 25.9)
            {
                weather = "Warm";
            }
            if (n >= 15.00 & n <= 20.00)
            {
                weather = "Mild";
            }
            if (n >= 12.00 & n <= 14.9)
            {
                weather = "Cool";
            }
            if (n >= 5.00 & n <= 11.9)
            {
                weather = "Cold";
            }

            Console.WriteLine(weather);
        }
    }
}
