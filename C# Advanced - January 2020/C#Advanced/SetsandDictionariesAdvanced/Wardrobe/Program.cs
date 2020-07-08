using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var clothes = tokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(tokens[0]))
                {
                    dict.Add(tokens[0], new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!dict[tokens[0]].ContainsKey(clothes[j])) dict[tokens[0]].Add(clothes[j], 1);
                    else dict[tokens[0]][clothes[j]]++;
                }
            }

            var lookingFor = Console.ReadLine().Split();

            foreach (var(color, clothes) in dict)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (key, value) in clothes)
                {
                    if (color == lookingFor[0] && key == lookingFor[1])
                    {
                        Console.WriteLine($"* {key} - {value} (found!)");
                    }
                    else Console.WriteLine($"* {key} - {value}");
                }
            }
        }
    }
}
