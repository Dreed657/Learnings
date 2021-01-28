using System;
using System.Linq;

namespace TriMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,,] matrix = new char[size, size, size];

            for (int l = 0; l < size; l++)
            {
                var sMatrix = new char[size, size];
                for (int r = 0; r < size; r++)
                {
                    var line = Console.ReadLine().ToCharArray();
                    for (int c = 0; c < size; c++)
                    {
                        matrix[r, c, l] = line[c];
                    }
                }
            }
        }
    }
}
