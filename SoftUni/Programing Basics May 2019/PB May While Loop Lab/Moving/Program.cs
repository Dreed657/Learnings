using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double totalBoxes = 0;
            double roomCubicMeters = width * lenght * height;
            double totalCubicMeters = 0;

            string command = Console.ReadLine();

            while (command != "Done")
            {
                int input = int.Parse(command);
                totalBoxes += input;
                if (totalBoxes > roomCubicMeters)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(totalCubicMeters)} Cubic meters more.");
                    break;
                }
            }

           
            if (command == "Done")
            {
                totalCubicMeters = roomCubicMeters - totalBoxes;

                Console.WriteLine($"{Math.Abs(totalCubicMeters)} Cubic meters left.");
            }
        }
    }
}
