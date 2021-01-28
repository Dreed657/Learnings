using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double finalGrade = 0;
            bool isExcluded = false;
            int attments = 0;

            while (counter < 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (attments > 0)
                {
                    isExcluded = true;
                    counter++;
                    break;
                }

                if (grade >= 4)
                {
                    finalGrade += grade;
                    counter++;
                }
                else
                {
                    attments++;
                }
            }

            if (isExcluded)
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
            else
            {
                finalGrade = finalGrade / 12;
                Console.WriteLine($"{name} graduated. Average grade: {finalGrade:F2}");
            }
        }
    }
}
