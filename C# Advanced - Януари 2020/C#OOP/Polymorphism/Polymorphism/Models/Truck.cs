namespace Polymorphism.Models
{
    using System;

    public class Truck : Vehicle
    {
        private const double moreConsumtionPerKm = 1.6;

        public Truck(double fuel, double consumtion, double tankCapacity)
            :base(fuel, consumtion, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => moreConsumtionPerKm;

        public override void Refuel(double amount)
        {
            if (amount * 0.95 <= 0) throw new ArgumentException("Fuel must be a positive number");

            if (this.Fuel + amount * 0.95 >= this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            this.Fuel += amount * 0.95;
        }
    }
}
