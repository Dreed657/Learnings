using System;

namespace _05._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double roomWidth = w * 100;
            double roomHeight = h * 100;
            double availableRoom = roomHeight - 100;
            double desksPerRow = availableRoom / 70;
            double rowsPerRoom = roomWidth / 120;
            double seats = (Math.Floor(desksPerRow) * Math.Floor(rowsPerRoom)) - 3;

            double maxSeats = Math.Round(seats);

            Console.WriteLine($"{maxSeats:N0}");
        }
    }
}
