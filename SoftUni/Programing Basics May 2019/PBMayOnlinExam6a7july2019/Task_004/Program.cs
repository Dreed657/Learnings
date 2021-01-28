using System;

namespace Task_004
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            double percentAreaNotPaintable = double.Parse(Console.ReadLine());

            double totalWallsArea = wallHeight * wallWidth * 4;
            double areaInPercentage = percentAreaNotPaintable / 100;
            double paintableArea = totalWallsArea - (totalWallsArea * areaInPercentage);

            bool tired = false;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tired!") { tired = true; break; }

                int wallLeft = int.Parse(input);
                paintableArea -= wallLeft;

                if (paintableArea <= 0) break;
            }


            if (tired == true)
                Console.WriteLine($"{paintableArea} quadratic m left.");
            else
            {
                if (paintableArea != 0)
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(paintableArea)} l paint left!");
                else
                    Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }

        }
    }
}
