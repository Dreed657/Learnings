using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                
                if (!dict.ContainsKey(input)) dict.Add(input, 1);
                
                dict[input]++;
            }

            foreach (var (key, value) in dict)
            {
                if (value % 2 == 1) Console.WriteLine(key);
            }
        }
    }
}
