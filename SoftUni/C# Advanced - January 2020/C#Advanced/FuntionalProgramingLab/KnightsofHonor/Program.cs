using System;
using System.Linq;
using System.Collections.Generic;

namespace KnightsofHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToList();

            Action<string> print = (x) => Console.WriteLine("Sir " + x);
            input.ForEach(x => print(x));
        }
    }
}
