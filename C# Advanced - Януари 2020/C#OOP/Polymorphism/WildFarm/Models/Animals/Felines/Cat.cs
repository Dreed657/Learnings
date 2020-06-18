namespace WildFarm.Models.Animals.Felines
{
    using System;

    using WildFarm.Models.Foods;

    public class Cat : Feline
    {
        protected override double WeightPerFood => 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void ValidateFood(Food food)
        {
            string type = food.GetType().Name;
            if (type != nameof(Meat) && type != nameof(Vegetable))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
        }
    }
}
