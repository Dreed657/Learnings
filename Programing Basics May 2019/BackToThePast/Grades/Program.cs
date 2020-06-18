using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double gradeSum = 0;

            double failGradesD = 0;
            double lowGradeD = 0;
            double goodGradesD = 0;
            double veryGoodGradesD = 0;

            for (int i = 0; i < n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradeSum += grade;

                if (grade < 3.00)
                    failGradesD++;
                else if (grade >= 3.00 && grade <= 3.99)
                    lowGradeD++;
                else if (grade >= 4.00 && grade <= 4.99)
                    goodGradesD++;
                else if (grade >= 5.00)
                    veryGoodGradesD++;

            }

            double averageGrade = gradeSum / n;

            double p1 = (failGradesD / n) * 100;
            double p2 = (lowGradeD / n) * 100;
            double p3 = (goodGradesD / n) * 100;
            double p4 = (veryGoodGradesD / n) * 100;

            Console.WriteLine($"Top students: {p4:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {p3:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {p2:F2}%");
            Console.WriteLine($"Fail: {p1:F2}%");
            Console.WriteLine($"Average: {averageGrade:F2}");
        }
    }
}
