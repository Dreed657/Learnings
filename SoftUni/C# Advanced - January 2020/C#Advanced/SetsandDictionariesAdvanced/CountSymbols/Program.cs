using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var curChar = input[i];
                if (!dict.ContainsKey(curChar)) dict.Add(curChar, 1);
                else dict[curChar]++;
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
