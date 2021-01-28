using System;
using System.Linq;

namespace MultidimensionalArraysExersise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int PrimarySum = 0;
            int SecondarySum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        var cur = matrix[i, j];
                        PrimarySum += cur;
                    }

                    if ((i + j) == (n - 1))
                    {
                        var cur = matrix[i, j];
                        SecondarySum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(PrimarySum - SecondarySum));
        }
    }
}
