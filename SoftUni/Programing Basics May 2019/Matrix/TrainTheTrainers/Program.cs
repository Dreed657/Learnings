using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());

            double gradeSum = 0;
            double gradeCount = 0;
            double generalSum = 0;
            double assamentCount = 0;

            while (true)
            {
                string assament = Console.ReadLine();
                if (assament == "Finish")
                    break;

                for (int i = 0; i < juryCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                    gradeCount++;
                }
                double gradeAvg = gradeSum / gradeCount;
                generalSum += gradeAvg;

                gradeSum = 0;
                gradeCount = 0;

                Console.WriteLine($"{assament} - {gradeAvg:F2}.");
                assamentCount++;
            }

            double generalAvg = generalSum / assamentCount;
            Console.WriteLine($"Student's final assessment is {generalAvg:F2}.");
        }
    }
}
