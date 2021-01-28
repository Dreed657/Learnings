using System;

namespace _04._Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tablesCount = int.Parse(Console.ReadLine());
            double LengthTable = double.Parse(Console.ReadLine());
            double widthTable = double.Parse(Console.ReadLine());

            double coverArea = tablesCount * (LengthTable + 2 * 0.30) * (widthTable + 2 * 0.30);
            double squareArea = tablesCount * (LengthTable / 2) * (LengthTable / 2);

            double price = coverArea * 7 + squareArea * 9;
            double priceBGN = price * 1.85;

            Console.WriteLine($"{price:F2} USD");
            Console.WriteLine($"{priceBGN:F2} BGN");
        }
    }
}
