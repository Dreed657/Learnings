using System;

namespace EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = Math.Abs(int.Parse(Console.ReadLine()));
                if (!(n % 2 == 0))
                    Console.WriteLine("Please write an even number.");
                else
                {
                    Console.WriteLine($"The number is: {n}");
                    break;
                }
            }
        }
    }
}
