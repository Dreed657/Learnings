using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] scrambaled = new int[numbers.Length];

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                scrambaled[numbers.Length - i - 1] = numbers[i];
            }

            foreach (var item in scrambaled)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
