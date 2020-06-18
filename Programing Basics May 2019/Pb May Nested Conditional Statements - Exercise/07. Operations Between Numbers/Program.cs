using System;

namespace _07._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            double result = 0.0d;
            string eveness = "Placeholder";

            if (operators == "+")
            {
                result = n1 + n2;
                if (result % 2 == 0)
                    eveness = "even";
                else
                    eveness = "odd";
                Console.WriteLine($"{n1} {operators} {n2} = {result} - {eveness}");
            }
            else if (operators == "-")
            {
                result = n1 - n2;
                if (result % 2 == 0)
                    eveness = "even";
                else
                    eveness = "odd";
                Console.WriteLine($"{n1} {operators} {n2} = {result} - {eveness}");

            }
            else if (operators == "*")
            {
                result = n1 * n2;
                if (result % 2 == 0)
                    eveness = "even";
                else
                    eveness = "odd";
                Console.WriteLine($"{n1} {operators} {n2} = {result} - {eveness}");
            }
            else if (operators == "/")
            {
                if (n1 == 0 || n2 == 0)
                    Console.WriteLine($"Cannot divide {n1} by zero");
                else
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} {operators} {n2} = {result:F2}");
                }
            }
            else if (operators == "%")
            {
                if (n1 == 0 || n2 == 0)
                    Console.WriteLine($"Cannot divide {n1} by zero");
                else
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} {operators} {n2} = {result}");
                }
            }
        }
    }
}
