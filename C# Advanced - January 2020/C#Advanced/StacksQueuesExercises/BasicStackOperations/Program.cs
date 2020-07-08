using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = tokens[0];
            int s = tokens[1];
            int x = tokens[2];

            var input = Console.ReadLine().Split().Select(int.Parse);
            var stack = new Stack<int>(input.ToArray());

            for (int i = 0; i < s; i++) stack.Pop();

            if (stack.Contains(x)) Console.WriteLine("true");
            else
                if (stack.Any()) Console.WriteLine(stack.Min());
                else Console.WriteLine("0");
        }
    }
}
