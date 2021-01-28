using System;

namespace Programing_Fund_Mid_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = int.Parse(Console.ReadLine()); 
            double stepLength = double.Parse(Console.ReadLine()); // CM
            int totalDistance = int.Parse(Console.ReadLine()) * 100; // CM 

            int totalShortSteps = totalSteps / 5;
            double shortSteps = stepLength - (stepLength * 0.30);
            double shortStepDistance = totalShortSteps * shortSteps;

            double distanceTraveled = ((totalSteps - totalShortSteps) * stepLength) + shortStepDistance;  // CM
            double percentage = (distanceTraveled / totalDistance) * 100;

            Console.WriteLine($"You travelled {percentage:F2}% of the distance!");
        }
    }
}
