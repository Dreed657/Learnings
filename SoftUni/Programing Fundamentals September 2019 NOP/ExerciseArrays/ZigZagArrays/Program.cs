using System;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] EvenNumbers = new int[n];
            int[] OddNumbers = new int[n];


            for (int i = 1; i <= n; i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    EvenNumbers[i - 1] = int.Parse(currentRow[0]);
                    OddNumbers[i - 1] = int.Parse(currentRow[1]);
                }
                else
                {
                    EvenNumbers[i - 1] = int.Parse(currentRow[1]);
                    OddNumbers[i - 1] = int.Parse(currentRow[0]);
                }
            }

            foreach (var item in OddNumbers)
                Console.Write($"{item} ");

            Console.WriteLine();

            foreach (var item in EvenNumbers)
                Console.Write($"{item} ");

            Console.WriteLine();
        }
    }
}
