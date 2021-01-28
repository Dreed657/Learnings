using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new string[tokens[0], tokens[1]];

            for (int i = 0; i < tokens[0]; i++)
            {
                var matrixInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tokens[1]; j++)
                {
                    matrix[i, j] = matrixInput[j];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END") break;
                
                if(input[0] == "swap" && input.Length <= 5)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);

                    if ((row1 >= 0 && row1 < matrix.GetLength(0)) &&
                        (col1 >= 0 && col1 < matrix.GetLength(1)) &&
                        (row2 >= 0 && row2 < matrix.GetLength(0)) &&
                        (col2 >= 0 && col2 < matrix.GetLength(1)))
                    {
                        var currentCell = matrix[row1, col1];
                        var slapCell = matrix[row2, col2];
                        matrix[row1, col1] = slapCell;
                        matrix[row2, col2] = currentCell;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Invalid input!");
                }
                else Console.WriteLine("Invalid input!");
            }
        }
    }
}
