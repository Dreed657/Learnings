using System;
using System.Linq;

namespace SquaresinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new char[tokens[0], tokens[1]];

            for (int i = 0; i < tokens[0]; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < tokens[1]; j++) matrix[i, j] = input[j];
            }

            int count = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var tempMatrix = new char[2, 2];
                    tempMatrix[0, 0] = matrix[i, j];
                    tempMatrix[0, 1] = matrix[i, j + 1];
                    tempMatrix[1, 0] = matrix[i + 1, j];
                    tempMatrix[1, 1] = matrix[i + 1, j + 1];

                    if (matrixEqulity(tempMatrix)) count++;
                }
            }

            Console.WriteLine(count);
        }

        public static bool matrixEqulity(char[,] matrix)
        {
            bool stillEqual = false;

            foreach (var cur in matrix)
            {
                foreach (var element in matrix)
                {
                    if (cur == element) stillEqual = true;
                    else
                    {
                        stillEqual = false;
                        break;
                    }
                }
            }

            return stillEqual;
        }
    }
}
