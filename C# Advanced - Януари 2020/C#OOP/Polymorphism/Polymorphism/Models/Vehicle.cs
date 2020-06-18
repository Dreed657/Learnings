namespace Polymorphism.Models
{
    using System;

    public abstract class Vehicle
    {
        private double fuel;

        public Vehicle(double fuel , double consumtion, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.Consumtion = consumtion;
        }

        public double Fuel 
        {
            get => this.fuel; 
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else this.fuel = value;
            } 
        }

        public double Consumtion { get; set; }

        protected abstract double AdditionalConsumption { get; }

        public double TankCapacity { get; set; }

        public string Drive(double distance)
        {
            var fuelNeeded = (this.Consumtion + this.AdditionalConsumption) * distance;

            if (this.Fuel >= fuelNeeded)
            {
                this.Fuel -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Fuel must be a positive number");

            if (this.Fuel + amount >= this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            
            this.Fuel += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }
    }
}
