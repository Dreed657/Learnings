using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxofString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var box = new Box<string>(list);

            var token = Console.ReadLine();

            Console.WriteLine(box.Compare(token));
        }
    }
}
