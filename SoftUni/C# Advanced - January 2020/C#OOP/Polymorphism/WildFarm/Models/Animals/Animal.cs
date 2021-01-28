namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using WildFarm.Models.Foods;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected abstract double WeightPerFood { get; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public double Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public int FoodEaten
        {
            get => this.foodEaten;
            set => this.foodEaten = value;
        }

        public void Eat(Food food)
        {
            this.ValidateFood(food);

            this.FoodEaten += food.Quantity;
            this.Weight += this.WeightPerFood * food.Quantity;
        }

        public abstract string ProduceSound();

        public abstract void ValidateFood(Food food);
    }
}
