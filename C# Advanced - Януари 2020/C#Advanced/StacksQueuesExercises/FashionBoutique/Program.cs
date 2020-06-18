using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(input);
            int stackCapacity = int.Parse(Console.ReadLine());
            int racksCount = 1;
            var sum = 0;

            while (stack.Any())
            {

                sum += stack.Peek();
                if (sum <= stackCapacity) stack.Pop();
                else
                {
                    racksCount++;
                    sum = 0;
                }
            }

            if (stack.Any()) racksCount++;

            Console.WriteLine(racksCount);
        }
    }
}
