using System;
using System.Linq;
using System.Collections.Generic;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrix = new int[tokens[0], tokens[1]];

            for (int i = 0; i < tokens[0]; i++)
            {
                var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var maxSum = int.MinValue;
            var biggestSquereTop = new int[2,2];

            for (int i = 0; i < tokens[0] - 1; i++)
            {

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var sum = 0;

                    var biggestSquere = new int[2, 2];
                    sum += matrix[i, j];
                    biggestSquere[0, 0] = matrix[i, j];
                    sum += matrix[i, j + 1];
                    biggestSquere[0, 1] = matrix[i, j + 1];
                    sum += matrix[i + 1, j];
                    biggestSquere[1, 0] = matrix[i + 1, j];
                    sum += matrix[i + 1, j + 1];
                    biggestSquere[1, 1] = matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        biggestSquereTop = biggestSquere;
                        maxSum = sum;
                    }
                }
               
            }

            for (int i = 0; i < biggestSquereTop.GetLength(0); i++)
            {
                for (int j = 0; j < biggestSquereTop.GetLength(1); j++)
                {
                    Console.Write(biggestSquereTop[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
