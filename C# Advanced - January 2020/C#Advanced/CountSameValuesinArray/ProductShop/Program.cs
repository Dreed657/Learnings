using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var tokens = Console.ReadLine().Split(", ");
                if (tokens[0] == "Revision") break;
            
                if(!stores.ContainsKey(tokens[0]))
                {
                    stores.Add(tokens[0], new Dictionary<string, double>());
                }

                if(!stores[tokens[0]].ContainsKey(tokens[1]))
                {
                    stores[tokens[0]].Add(tokens[0], 0);
                }

                stores[tokens[0]][tokens[1]] = double.Parse(tokens[2]);
            }

            foreach (var (key, value) in stores)
            {
                Console.WriteLine($"{key}->");

                foreach (var (product, price) in value)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
