using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcRect(x, y));
        }

        static int CalcRect(int x, int  y)
        {
            return x * y;
        }
    }
}
