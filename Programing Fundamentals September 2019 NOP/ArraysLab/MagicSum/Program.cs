using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int wantedNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
                for (int j = i; j < input.Length - 1; j++)
                {
                    int firstNumber = input[i];
                    int secondNumber = input[j + 1];

                    if (firstNumber + secondNumber == wantedNumber) Console.WriteLine($"{firstNumber} {secondNumber}");
                }
        }
    }
}
