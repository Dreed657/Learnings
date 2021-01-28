using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var engines = new HashSet<Engine>();
            var cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    engines.Add(new Engine(tokens[0], int.Parse(tokens[1])));
                }
                else if (tokens.Length == 3)
                {
                    if (char.IsLetter(tokens[2][0]))
                    {
                        engines.Add(new Engine(tokens[0], int.Parse(tokens[1]), tokens[2]));
                    }
                    else
                    {
                        engines.Add(new Engine(tokens[0], int.Parse(tokens[1]), double.Parse(tokens[2])));
                    }
                }
                else
                {
                    engines.Add(new Engine(tokens[0], int.Parse(tokens[1]), double.Parse(tokens[2]), tokens[3]));
                }
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engine = engines.First(x => x.Model == tokens[1]);

                if (tokens.Length == 2)
                {
                    cars.Add(new Car(tokens[0], engine));
                }
                else if (tokens.Length == 3)
                {
                    if (char.IsLetter(tokens[2][0]))
                    {
                        cars.Add(new Car(tokens[0], engine, tokens[2]));
                    }
                    else
                    {
                        cars.Add(new Car(tokens[0], engine, double.Parse(tokens[2])));
                    }
                }
                else
                {
                    cars.Add(new Car(tokens[0], engine, double.Parse(tokens[2]), tokens[3]));
                }
            }

            foreach (var car in cars)
            {
                if (car != null) Console.WriteLine(car.ToString());
            }
        }
    }
}
