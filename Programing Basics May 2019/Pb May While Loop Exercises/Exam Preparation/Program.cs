using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesCount = int.Parse(Console.ReadLine());
            string nameOfExercise = string.Empty;

            int poorGrade = 0;
            double grade = 0.0d;
            double averageGrade = 0.0d;
            int taskCount = 0;
            string lastExercise = string.Empty;

            while (nameOfExercise != "Enough")
            {
                nameOfExercise = Console.ReadLine();
                if (nameOfExercise == "Enough")
                {
                    averageGrade = grade / taskCount;
                    if (nameOfExercise == "Enough")
                    {
                        Console.WriteLine($"Average score: {averageGrade:F2}");
                        Console.WriteLine($"Number of problems: {taskCount}");
                        Console.WriteLine($"Last problem: {lastExercise}");
                    }
                }
                else
                {
                    int gradeOfExercise = int.Parse(Console.ReadLine());
                    grade += gradeOfExercise;
                    if (gradeOfExercise <= 4)
                    {
                        poorGrade++;
                    }
                    if (poorGrade >= poorGradesCount)
                    {
                        Console.WriteLine($"You need a break, {poorGrade} poor grades.");
                        break;
                    }
                }

                lastExercise = nameOfExercise;
                taskCount++;
            }
        }
    }
}
