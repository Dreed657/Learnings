using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_ofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var nSet = new List<int>();
            var mSet = new HashSet<int>();
            var uniquePaires = new HashSet<int>();

            for (int i = 0; i < tokens[0]; i++) nSet.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < tokens[1]; i++) mSet.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < nSet.Count; i++)
            {
                if (mSet.Contains(nSet[i])) uniquePaires.Add(nSet[i]);
            }

            Console.WriteLine(string.Join(' ', uniquePaires));
        }
    }
}
