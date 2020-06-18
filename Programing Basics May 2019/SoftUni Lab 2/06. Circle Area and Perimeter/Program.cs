using System;

namespace _06._Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double d = r * 2;
            double area = Math.PI * Math.Pow(d / 2, 2);
            double perimeter = Math.PI * d;
            double roundArea = Math.Round(area, 2);
            double roundPerimeter = Math.Round(perimeter, 2);

            Console.WriteLine(roundArea);
            Console.WriteLine(roundPerimeter);
        }
    }
}
