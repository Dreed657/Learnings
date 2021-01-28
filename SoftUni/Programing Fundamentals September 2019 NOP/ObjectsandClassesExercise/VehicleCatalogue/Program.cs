using System;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> Catalog = new List<Vehicle>();
            int carsCount = 0;
            int trucksCount = 0;
            double totalCarsHp = 0;
            double totalTrucksHp = 0;

            List<Vehicle> print = new List<Vehicle>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End") break;

                string type = input[0];
                string model = input[1];
                string color = input[2];
                int hp = int.Parse(input[3]);

                switch (type)
                {
                    case "car":
                        type = "Car";
                        carsCount++;
                        totalCarsHp += int.Parse(input[3]);
                        break;
                    case "truck":
                        type = "Truck";
                        trucksCount++;
                        totalTrucksHp += int.Parse(input[3]);
                        break;
                }

                Vehicle curVehicle = new Vehicle(type, model, color, hp);
                Catalog.Add(curVehicle);
            }

            while (true)
            {
                string token = Console.ReadLine();
                if (token == "Close the Catalogue") break;

                print.Add(Catalog.Find(x => x.Model == token));
            }

            foreach (var item in print)
            {
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Color: {item.Color}");
                Console.WriteLine($"Horsepower: {item.HorsePower}");
            }

            if (carsCount > 0)
            {
                double avgCarHp = Math.Round(totalCarsHp / carsCount, 2);
                Console.WriteLine($"Cars have average horsepower of: {avgCarHp:F2}.");
            }
            else Console.WriteLine($"Cars have average horsepower of: {0:F2}.");

            if (trucksCount > 0)
            {
                double avgTruckHp = Math.Round(totalTrucksHp / trucksCount, 2);
                Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:F2}.");
            }
            else Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
