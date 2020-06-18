using System;

namespace _01_Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            string grade = "";

            if (n >= 5.5)
                grade = "Excellent!";

            Console.WriteLine(grade);
        }
    }
}
