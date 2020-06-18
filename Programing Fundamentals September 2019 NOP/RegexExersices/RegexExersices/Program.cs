using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexExersices
{
    class Program
    {
        static void Main(string[] args)
        {
            var Cart = new Dictionary<string, double>();
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d+)!(\d+)";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase") break;

                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);

                    double totalPrice = quantity * price;

                    if(!Cart.ContainsKey(name))
                    {
                        Cart.Add(name, 0);
                    }
                    Cart[name] += totalPrice;
                }
            }
            double totalMoneySpent = 0;

            Console.WriteLine("Bought furniture:");
            foreach (var item in Cart)
            {
                Console.WriteLine(item.Key);
                totalMoneySpent += item.Value;
            }
            Console.WriteLine($"Total money spend: {totalMoneySpent}");
        }
    }
}
