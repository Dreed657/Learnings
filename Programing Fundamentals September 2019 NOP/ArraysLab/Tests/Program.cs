using System;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Reverse(input);

            foreach (var item in input)
                Console.WriteLine(item);
        }
    }
}
