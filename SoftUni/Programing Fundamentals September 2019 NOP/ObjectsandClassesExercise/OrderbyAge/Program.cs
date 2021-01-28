using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderbyAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> group = new List<Person>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0] == "End") break;

                Person person = new Person(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));
                group.Add(person);
            }

            group = group.OrderBy(x => x.Age).ToList();

            foreach (var item in group) item.print();
        }
    }

    class Person
    {
        public Person(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }
        
        public void print()
        {
            Console.WriteLine($"{Name} with ID: {Id} is {Age} years old.");
        }
    }
}
