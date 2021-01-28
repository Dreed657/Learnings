using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int length = input.Length;
            if (length % 2 == 0)
            {
                string result = $"{input[length / 2 - 1]}{input[length / 2]}";
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(input[length / 2]);
            }
        }
    }
}
