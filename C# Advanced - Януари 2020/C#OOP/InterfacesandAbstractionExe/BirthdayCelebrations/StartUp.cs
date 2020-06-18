namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    people.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    people.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
            }

            while (true)
            {
                var token = Console.ReadLine();
                if (token == "End") break;

                var curPerson = people.FirstOrDefault(x => x.Name == token);

                if (curPerson != null)
                {
                    curPerson.BuyFood();
                }
            }

            Console.WriteLine(people.Sum(b => b.Food));
        }
    }
}
