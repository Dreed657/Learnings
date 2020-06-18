using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;

                int n, r, sum = 0, temp;
                n = int.Parse(input);
                temp = n;
                while (n > 0)
                {
                    r = n % 10;
                    sum = (sum * 10) + r;
                    n = n / 10;
                }

                if (temp == sum) Console.WriteLine("true");
                else Console.WriteLine("false");
            }
        }
    }
}
