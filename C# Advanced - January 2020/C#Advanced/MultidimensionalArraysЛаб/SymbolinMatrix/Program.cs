using System;
using System.Linq;

namespace SymbolinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool occur = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        occur = true;
                        break;
                    }
                }
                if (occur) break;
            }

            if (!occur) Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
