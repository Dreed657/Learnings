using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (tokens[0])
                {
                    case 1:
                        //Push
                        stack.Push(tokens[1]);
                        break;
                    case 2:
                        //Delete
                        if (stack.Any()) stack.Pop();
                        break;
                    case 3:
                        //Print Max
                        if (stack.Any()) Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        //Print Min
                        if (stack.Any()) Console.WriteLine(stack.Min());
                        break;
                }
            }
            if (stack.Any()) Console.WriteLine(string.Join(", ", stack));
        }
    }
}
