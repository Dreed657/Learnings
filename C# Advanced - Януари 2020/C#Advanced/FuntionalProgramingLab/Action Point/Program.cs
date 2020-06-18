using System;
using System.Linq;
using System.Collections.Generic;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> print = (x) => Console.WriteLine(x);
            input.ForEach(x => print(x));
        }
    }
}
