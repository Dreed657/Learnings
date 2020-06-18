using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> wordIndexed = input.ToList();

            for (int i = 1; i < wordIndexed.Count; i++)
            {
                char previous = wordIndexed[i - 1];
                char current = wordIndexed[i];

                if (current == previous)
                {
                    wordIndexed.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", wordIndexed));
        }
    }
}
