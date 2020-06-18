using System;

namespace ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] table = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                for (int r = 0; r < tokens.Length; r++)
                {
                    table[i, r] = tokens[r];
                }
            }

            var sortTokens = Console.ReadLine().Split();

        }
    }
}
