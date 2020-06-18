using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> FindMin = (n) =>
            {
                var minNum = int.MaxValue;

                for (int i = 0; i < n.Count; i++) if (n[i] < minNum) minNum = n[i];

                return minNum;
            };

            Console.WriteLine(FindMin(input));
        }
    }
}
