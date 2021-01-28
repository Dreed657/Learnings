using System;

namespace GiftBoxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int paperCount = int.Parse(Console.ReadLine());
            double sheetArea = double.Parse(Console.ReadLine());

            double boxSizeArae = sideSize * sideSize * 6;
            double totalPaperArea = 0;
            int counter = 0;
            int resCount = 0;

            while (!(counter == paperCount))
            {
                resCount++;
                counter++;

                if (resCount == 3)
                {
                    totalPaperArea += sheetArea * 0.25;
                    resCount = 0;
                }
                else totalPaperArea += sheetArea;
            }

            double calcPercentage = (totalPaperArea / boxSizeArae) * 100;

            Console.WriteLine($"You can cover {calcPercentage:F2}% of the box.");
        }
    }
}
