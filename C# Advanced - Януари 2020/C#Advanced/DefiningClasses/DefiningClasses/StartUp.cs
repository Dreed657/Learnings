using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                family.Add(person);
            }

            family = family.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, family));
        }
    }
}
