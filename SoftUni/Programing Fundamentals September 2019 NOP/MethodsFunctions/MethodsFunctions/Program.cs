using System;

namespace MethodsFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            Console.WriteLine(GetGrade(grade));
        }

        static string GetGrade(double grade)
        {
            string res = string.Empty;

            if (grade <= 2.99) res = "Fail";
            else if (grade >= 3.00 && grade <= 3.49) res = "Poor";
            else if (grade >= 3.50 && grade <= 4.49) res = "Good";
            else if (grade >= 4.50 && grade <= 5.49) res = "Very good";
            else if (grade >= 5.50 && grade <= 6.00) res = "Excellent";

            return res;
        }
    }
}
