using System;
using System.Linq;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (IsStrongNumber(n)) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
        public static bool IsStrongNumber(int number)
        {
            long fact;
            int num = number;
            long sum = 0;

            while (number != 0)
            {
                fact = 1;

                for (int i = 1; i <= number % 10; ++i)
                    fact *= i;

                sum += fact;
                    
                number /= 10;
            }

            return sum == num;
        }
    }
}
