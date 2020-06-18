using System;
using System.Collections.Generic;
using System.Linq;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToList();

            for (int i = 0; i < input.Count; i++)
            {
                char current = input[i];
                int strength = 0;

                if (current == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    for (int j = i; j < strength; j++)
                    {
                        if (input[j + 1] == '>') strength += int.Parse(input[j + 1].ToString());
                        input.RemoveAt(j);
                        i--;
                    }
                }
            }
         
            Console.WriteLine(string.Join("", input));
        }
    }
}
