using System;

namespace SignofIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(getAbs(int.Parse(Console.ReadLine())));
        }

        static string getAbs(int number)
        {
            string res = string.Empty;

            if (number > 0) res = $"The number {number} is positive.";
            else if (number < 0) res = $"The number {number} is negative.";
            else res = "The number 0 is zero.";

            return res;
        }
    }
}
