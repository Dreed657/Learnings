using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSequenceofEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int bestCount = 1;
            int bestNum = 0;
            int count = 1;
          
            for (int i = 0; i < input.Length - 1; i++)
            {
                int element = input[i];
                int nextElement = input[i + 1];

                if (element == nextElement) count++;
                else count = 1;

                if (count > bestCount)
                {
                    bestCount = count;
                    bestNum = nextElement;
                }
            }

            for (int i = 0; i < bestCount; i++)
                Console.Write(bestNum + " ");
        }
    }
}
