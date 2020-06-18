using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int height = n * 2 - (n / 2) - 1;
            int total = n * height;

            string empty = "...";
            char full = '#';

            var sb = new StringBuilder();

            for (int i = 0; i < total; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(full);
                }
                else
                {
                    sb.Append(empty);
                }

                if (sb.Length >= total) break;
            }

            var parts = Split(sb.ToString(), n);

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
