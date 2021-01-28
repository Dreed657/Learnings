using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();

                switch (int.Parse(tokens[0]))
                {
                    case 1:
                        if (stack.Any()) stack.Push(stack.Peek() + tokens[1]);
                        else stack.Push(tokens[1]);
                        break;
                    case 2:
                        int count = int.Parse(tokens[1]);
                        stack.Push(stack.Peek().Remove(stack.Peek().Length - count));
                        break;
                    case 3:
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(stack.Peek()[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        break;
                    default: break;
                }
            }
        }
    }
}
