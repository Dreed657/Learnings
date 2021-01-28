namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const decimal CoffeePrice = 3.50m;
        public const double CoffeeMills = 50;

        public Coffee(string name, double caffeine) :base(name, CoffeePrice, CoffeeMills)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
