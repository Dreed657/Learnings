namespace WildFarm.Models.Animals.Mammals
{
    using System;

    using WildFarm.Models.Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.10;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void ValidateFood(Food food)
        {
            string type = food.GetType().Name;
            if (type != nameof(Vegetable) && type != nameof(Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
        }
    }
}
