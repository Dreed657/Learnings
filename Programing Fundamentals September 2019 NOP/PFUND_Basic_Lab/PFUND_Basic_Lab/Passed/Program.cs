using System;

namespace Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop") break;

                double grade = double.Parse(input);
                if (grade >= 3.00) Console.WriteLine("passed!");
            }
        }
    }
}
