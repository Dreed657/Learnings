using System;
using System.Collections.Generic;
using System.Linq;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelsCounter(input));
        }

        static int VowelsCounter(string word)
        {
            word = word.ToLower();

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int total = word.Count(c => vowels.Contains(c));

            return total;
        }
    }
}
