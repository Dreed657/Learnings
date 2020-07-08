using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateforNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .ToList();

            Action<List<string>> printValid = new Action<List<string>>(x =>
            {
                input.Where(x => x.Length <= n)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));
            });

            printValid(input);
        }
    }
}
