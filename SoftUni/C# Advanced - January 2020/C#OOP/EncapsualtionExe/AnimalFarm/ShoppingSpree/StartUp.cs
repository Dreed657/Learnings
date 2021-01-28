using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            foreach (var item in peopleInput)
            {
                var tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    people.Add(new Person(tokens[0], double.Parse(tokens[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach (var item in productsInput)
            {
                var tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    products.Add(new Product(tokens[0], double.Parse(tokens[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "END") break;

                var person = people.FirstOrDefault(x => x.Name == tokens[0]);
                var product = products.FirstOrDefault(x => x.Name == tokens[1]);

                if (person != null && product != null)
                {
                    try
                    {
                        person.BuySomething(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            people.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
