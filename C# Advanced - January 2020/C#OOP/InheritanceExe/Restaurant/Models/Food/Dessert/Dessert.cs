using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, int calories) : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public int Calories { get; set; }
    }
}
