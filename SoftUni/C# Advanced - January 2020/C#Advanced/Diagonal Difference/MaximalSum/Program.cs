using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[tokens[0], tokens[1]];

            for (int i = 0; i < tokens[0]; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < tokens[1]; j++) matrix[i, j] = input[j]; 
            }

            int biggestSum = int.MinValue;
            var biggestList = new List<int>();

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var tempSum = 0;
                    var tempList = new List<int>();

                    if(i + 3 <= matrix.GetLength(0) && j + 3 <= matrix.GetLength(1))
                    {
                        for (int row = i; row < i + 3; row++)
                        {
                            for (int col = j; col < j + 3; col++)
                            {
                                tempSum += matrix[row, col];
                                tempList.Add(matrix[row, col]);
                            }
                        }
                    }

                    if (tempSum > biggestSum)
                    {
                        biggestSum = tempSum;
                        biggestList = tempList;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            for (int i = 0; i < biggestList.Count; i++)
            {
                if (i % 3 == 0 && i != 0) Console.WriteLine();
                
                Console.Write(biggestList[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
