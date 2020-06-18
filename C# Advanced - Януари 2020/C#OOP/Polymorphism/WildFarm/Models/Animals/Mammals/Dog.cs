namespace WildFarm.Models.Animals.Mammals
{
    using System;

    using WildFarm.Models.Foods;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.40;

        public override string ProduceSound()
        {
            return "Woof!";
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
