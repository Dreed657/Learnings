namespace WildFarm.Models.Animals.Felines
{
    using System;

    using WildFarm.Models.Foods;

    public class Tiger : Feline
    {
        protected override double WeightPerFood => 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void ValidateFood(Food food)
        {
            string type = food.GetType().Name;
            if (type != nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
        }
    }
}
