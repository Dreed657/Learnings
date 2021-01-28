using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxLength = 15;
        private const int MinToppings = 0;
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length > MaxLength)
                {
                    throw new ArgumentException(Exceptions.InvalidPizzaName);
                }

                this.name = value;
            }
        }

        public int ToppingsCount => this.toppings.Count;
       
        public double TotalCalories => this.TotalColories();

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count < MinToppings || this.toppings.Count > MaxToppings)
            {
                throw new AggregateException(Exceptions.InvalidToppingsRange);
            }

            this.toppings.Add(topping);
        }

        private double TotalColories()
        {
            double doughCalories = this.dough.Calories;
            double totalToppingsCalories = 0;

            toppings.ForEach(x => totalToppingsCalories += x.Calories);

            return doughCalories + totalToppingsCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
