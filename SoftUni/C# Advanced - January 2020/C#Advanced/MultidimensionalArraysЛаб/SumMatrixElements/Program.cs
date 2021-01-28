using System;
using System.Linq;
using System.Collections.Generic;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var matrix = new int[tokens[0], tokens[1]];
            int sum = 0;

            for (int i = 0; i < tokens[0]; i++)
            {
                var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                    sum += input[j];
                }
            }

            Console.WriteLine(tokens[0]);
            Console.WriteLine(tokens[1]);
            Console.WriteLine(sum);
        }
    }
}
