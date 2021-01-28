using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueue
{
    class ReverseString
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

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "END") break;

                int x = 0;
                int y = 0;
                int value = 0;

                switch (tokens[0])
                {
                    case "Add":
                        x = int.Parse(tokens[1]);
                        y = int.Parse(tokens[2]);
                        value = int.Parse(tokens[3]);
                        
                        try
                        {
                            matrix[x, y] += value;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                    case "Subtract":
                        x = int.Parse(tokens[1]);
                        y = int.Parse(tokens[2]);
                        value = int.Parse(tokens[3]);

                        try
                        {
                            matrix[x, y] -= value;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}