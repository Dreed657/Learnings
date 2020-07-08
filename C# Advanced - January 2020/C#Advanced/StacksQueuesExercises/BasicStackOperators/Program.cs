using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int N = tokens[0];
            int S = tokens[1];
            int X = tokens[2];

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var queue = new Queue<int>(input);

            for (int i = 0; i < S; i++)
                queue.Dequeue();

            if (queue.Contains(X)) Console.WriteLine("true");
            else
                if (queue.Any()) Console.WriteLine(queue.Min());
                else Console.WriteLine("0");
        }
    }
}
