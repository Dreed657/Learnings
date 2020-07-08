using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var numbers = new Stack<int>();
            input.ForEach(x => numbers.Push(x));

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0].ToLower() == "end") break;

                string command = tokens[0].ToLower();

                switch (command) 
                {
                    case "add":
                        numbers.Push(int.Parse(tokens[1]));
                        numbers.Push(int.Parse(tokens[2]));
                        break;
                    case "remove":
                        int n = int.Parse(tokens[1]);
                        if (numbers.Count >= n)
                            for (int i = 0; i < n; i++)
                                numbers.Pop();
                        break;
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
