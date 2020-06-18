namespace WildFarm.Models.Animals.Birds
{
    using System;

    using WildFarm.Models.Foods;
    
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.35;

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void ValidateFood(Food food)
        {
            string type = food.GetType().Name;
            if (type != nameof(Meat) && type != nameof(Vegetable) && type != nameof(Fruit) && type != nameof(Seeds))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
        }
    }
}
