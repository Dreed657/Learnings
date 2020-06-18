using System;

namespace _06._Number_100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());

            if (n1 < 100)
                Console.WriteLine("Less than 100");
            else if ( n1 >= 100 & n1 <= 200)
                Console.WriteLine("Between 100 and 200");
            else
                Console.WriteLine("Greater than 200");
        }
    }
}
