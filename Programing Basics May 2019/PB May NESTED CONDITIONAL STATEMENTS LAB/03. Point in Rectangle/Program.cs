using System;

namespace _03._Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool isInsideXside = x >= x1 && x <= x2;
            bool isInsideYside = y >= y1 && y <= y2;

            if ( isInsideXside && isInsideYside )
                Console.WriteLine("Inside");
            else
                Console.WriteLine("Outside");

        }
    }
}
