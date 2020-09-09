using System;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices;

namespace TestingBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[6][];

            for (var i = 0; i < 6; i++)
            {
                var arr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = arr;
            }

            var res = hourglassSum(matrix);
            Console.WriteLine(res);
        }

        static int hourglassSum(int[][] arr)
        {
            var maxSum = int.MinValue;
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    if (j + 2 >= 6 || i + 2 >= 6) continue;
                    
                    var sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
                              arr[i + 1][j + 1] + arr[i + 2][j] +
                              arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    maxSum = Math.Max(maxSum, sum);
                }
            }

            return maxSum;
        }
    }
}
