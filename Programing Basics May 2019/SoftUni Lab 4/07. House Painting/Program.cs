using System;

namespace _07._House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sideWallArea = x * y;
            double windowArea = 1.5 * 1.5;
            double twoSides = 2 * sideWallArea - 2 * windowArea;
            double backWall = x * x;
            double entrenceArea = 1.2 * 2;
            double bothWalls = 2 * backWall - entrenceArea;
            double fullArea = twoSides + bothWalls;
            double greenPaint = fullArea / 3.4;

            double roofSides = 2 * (x * y);
            double triangeSides = 2 * (x * h / 2);
            double roofArea = roofSides + triangeSides;
            double redPaint = roofArea / 4.3;

            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");
        }
    }
}
