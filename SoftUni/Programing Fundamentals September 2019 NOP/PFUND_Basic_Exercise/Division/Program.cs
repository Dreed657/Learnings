using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;

            if (n % 10 == 0) result = "The number is divisible by 10";
            else if (n % 7 == 0) result = "The number is divisible by 7";
            else if (n % 6 == 0) result = "The number is divisible by 6";
            else if (n % 3 == 0) result = "The number is divisible by 3";
            else if (n % 2 == 0) result = "The number is divisible by 2";
            else result = "Not divisible";

            Console.WriteLine(result);
        }

    }
}
