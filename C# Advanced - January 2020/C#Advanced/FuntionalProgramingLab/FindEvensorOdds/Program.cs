using System;
using System.Linq;
using System.Collections.Generic;

namespace FindEvensorOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string type = Console.ReadLine();

            var predicate = type == "even" ? new Predicate<long>((x) => x % 2 == 0) : 
                new Predicate<long>((x) => x % 2 != 0);

            var result = new List<long>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (predicate(i)) result.Add(i);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
