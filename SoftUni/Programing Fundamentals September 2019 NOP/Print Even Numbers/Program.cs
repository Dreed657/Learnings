using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var queue = new Queue<int>(input);
            var temp = new List<int>();

            while (queue.Any())
            {
                var curNumber = queue.Dequeue();
                if (curNumber % 2 == 0) temp.Add(curNumber);
            }
            Console.WriteLine(string.Join(", ", temp));
        }
    }
}
