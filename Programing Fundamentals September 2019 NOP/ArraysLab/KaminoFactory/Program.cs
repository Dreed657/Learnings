using System;
using System.Collections.Generic;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int bestCount = 0;
            int bestSum = 0;
            int bestStartIndex = 0;
            string bestSequence = string.Empty;
            int counter = 0;
            int bestCounter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Clone them!") break;

                string sequence = input.Replace("!", "");
                string[] DNA = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                string bestSubSequence = string.Empty;
                counter++;

                foreach (var item in DNA)
                {
                    if (item.Length > count)
                    {
                        count = item.Length;
                        bestSubSequence = item;
                    }
                    sum += item.Length;
                }

                int startIndex = sequence.IndexOf(bestSubSequence);

                if (    count > bestCount
                    || (count == bestCount && startIndex < bestStartIndex)
                    || (count == bestCount && startIndex == bestStartIndex && sum > bestSum
                    || counter == 1))
                {
                    bestCounter = counter;
                    bestSequence = sequence;
                    bestCount = count;
                    bestSum = sum;
                    bestStartIndex = startIndex;
                }
            }

            char[] sequenceSplit = bestSequence.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", sequenceSplit));
        }
    }
}
