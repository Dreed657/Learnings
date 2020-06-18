using System;

namespace _02._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());
            double income = 0.0d;

            double maxSeats = row * column;
            
            if (type == "Premiere")
            {
                income += maxSeats * 12.00;
                Console.WriteLine($"{income:F2}");
            }
            else if (type == "Normal")
            {
                income += maxSeats * 7.50;
                Console.WriteLine($"{income:F2}");
            }
            else if (type == "Discount")
            {
                income += maxSeats * 5.00;
                Console.WriteLine($"{income:F2}");
            }
        }
    }
}
