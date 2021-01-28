using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var model = tokens[0];
                var Engine = new Engine(double.Parse(tokens[1]), double.Parse(tokens[2]));
                var Cargo = new Cargo(double.Parse(tokens[3]), tokens[4]);
                var Tires = new List<Tire>
                {
                    new Tire(double.Parse(tokens[5]), double.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]), double.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]), double.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]), double.Parse(tokens[12]))
                };

                cars.Add(new Car(model, Engine, Cargo, Tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var temp = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(x => x.Pressure < 1))
                    .ToList();

                temp.ForEach(x => Console.WriteLine(x.Model));
            }
            else if (command == "flamable")
            {
                var temp = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.Power > 250)
                    .ToList();

                temp.ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
