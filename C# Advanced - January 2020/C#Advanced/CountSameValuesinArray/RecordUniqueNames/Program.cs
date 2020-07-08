using System;
using System.Linq;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < n; i++) set.Add(Console.ReadLine());

            foreach (var item in set) Console.WriteLine(item);
        }
    }
}
