using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public const double DefaultGrams = 250;
        public const int DefaultCalories = 1000;
        public const decimal DefaultPrice = 5;

        public Cake(string name) : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
