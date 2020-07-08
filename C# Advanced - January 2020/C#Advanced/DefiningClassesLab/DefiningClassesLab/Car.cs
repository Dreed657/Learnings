using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        private Tire[] tires;
        
        private Engine engine;

        public string Make
        {
            get
            {
                return this.make;
            }
            set => this.make = value;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set => this.model = value;
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set => this.year = value;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set => this.fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set => this.fuelConsumption = value;
        }

        public Engine Engine { get; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            var fuelNeeded = fuelConsumption * distance / 100;
            var canDrive = this.fuelQuantity - fuelNeeded >= 0;

            if (canDrive)
                this.fuelQuantity -= fuelNeeded;
            else
                Console.WriteLine("Not enough fuel to perform this trip!");
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString();
        }
    }
}
