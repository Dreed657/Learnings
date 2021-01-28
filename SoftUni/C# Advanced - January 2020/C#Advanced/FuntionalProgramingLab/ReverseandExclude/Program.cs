using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseandExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Action<int, int, List<int>> check = new Action<int, int, List<int>>((x, n, list) =>
            {
                if (x % n != 0) list.Add(x);
            });

            Func<int[], List<int>> print = new Func<int[], List<int>>(arr => 
            {
                var tempArr = new List<int>();

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    check(input[i], n, tempArr);
                }

                return tempArr;
            });

            Console.WriteLine(string.Join(' ', print(input)));
        }
    }
}
