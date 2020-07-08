namespace Polymorphism.Models
{
    public class Car : Vehicle
    {
        private const double moreConsumtionPerKm = 0.9;

        public Car(double fuel, double consumtion, double tankCapacity)
            : base(fuel, consumtion, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => moreConsumtionPerKm;
    }
}
