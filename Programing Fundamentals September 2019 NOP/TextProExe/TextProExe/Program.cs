using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextProExe
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var listOfNames = input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Where(l => l.Length >= 3 && l.Length <= 16)
                .Where(l => l.All(c => char.IsDigit(c) || char.IsLetter(c) || c == '-' || c == '_'))
                .ToList();

            listOfNames.ForEach(x => Console.WriteLine(x));
        }
    }
}
