using System;
using System.Linq;
using System.Collections.Generic;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrix = new int[tokens[0], tokens[1]];
            var result = new List<int>();

            for (int i = 0; i < tokens[0]; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < tokens[1]; i++)
            {
                var sum = 0;
                for (int j = 0; j < tokens[0]; j++)
                {
                    sum += matrix[j, i];
                }
                result.Add(sum);
            }

            result.ForEach(x => Console.WriteLine(x));
        }
    }
}
