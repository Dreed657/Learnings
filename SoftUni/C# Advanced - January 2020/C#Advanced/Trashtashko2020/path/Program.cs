using System;
using System.Collections.Generic;
using System.Linq;

namespace path
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().ToList();

            GetCombination(input);
        }

        static void GetCombination(List<char> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Console.Write(list[j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
