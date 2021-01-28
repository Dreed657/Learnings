using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double timeToAnotherEnd = double.Parse(Console.ReadLine());

            double totalSwim = distanceMeters * timeToAnotherEnd;
            double distancePerMeters = distanceMeters / 15;
            double distanceSum = Math.Floor(distancePerMeters) * 12.5;
            double totalTime = totalSwim + distanceSum;

            if (totalTime < recordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                totalTime = totalTime - recordSeconds;
                Math.Round(totalTime, 2);
                Console.WriteLine($"No, he failed! He was {totalTime:F2} seconds slower.");
            }
        }
    }
}
