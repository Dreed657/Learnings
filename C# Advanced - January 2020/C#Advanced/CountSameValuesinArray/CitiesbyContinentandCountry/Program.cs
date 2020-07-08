using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesbyContinentandCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (!continents.ContainsKey(tokens[0]))
                {
                    continents.Add(tokens[0], new Dictionary<string, List<string>>());
                }

                if (!continents[tokens[0]].ContainsKey(tokens[1]))
                {
                    continents[tokens[0]].Add(tokens[1], new List<string>());
                }

                continents[tokens[0]][tokens[1]].Add(tokens[2]);
            }

            foreach (var (key, value) in continents)
            {
                Console.WriteLine($"{key}:");

                foreach (var (country, cities) in value)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
