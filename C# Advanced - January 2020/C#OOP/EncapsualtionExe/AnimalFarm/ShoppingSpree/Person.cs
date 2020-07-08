using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> bagOfProducts;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<string>();
        }

        public string Name 
        { 
            get { return this.name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuySomething(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new Exception($"{this.name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;
            this.bagOfProducts.Add(product.Name);
        }

        public override string ToString()
        {
            var result = string.Empty;

            if (bagOfProducts.Count > 0)
            {
                result = $"{this.Name} - {string.Join(", ", this.bagOfProducts)}";
            }
            else
            {
                result = $"{this.Name} - Nothing bought";
            }

            return result;
        }
    }
}
