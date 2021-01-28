using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            printTriange(n);
        }

        static void printTriange(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
