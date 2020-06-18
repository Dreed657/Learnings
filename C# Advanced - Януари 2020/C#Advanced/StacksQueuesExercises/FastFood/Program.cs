using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQunatity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(input);

            Console.WriteLine(queue.Max());

            while (queue.Any())
            {
                if (queue.Peek() <= foodQunatity) foodQunatity -= queue.Dequeue();
                else break;
            }

            if (queue.Any()) Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            else Console.WriteLine("Orders complete");
        }
    }
}
