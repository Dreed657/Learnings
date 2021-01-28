using System;

namespace ReverseArrayofStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write($"{words[i]} ");
            }
            Console.WriteLine();
        }
    }
}
