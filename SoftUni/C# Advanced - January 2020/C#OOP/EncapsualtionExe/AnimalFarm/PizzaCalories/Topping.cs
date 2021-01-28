namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                // meat, veggies, cheese or a sauce

                var testValue = value.ToLower();

                if (testValue != "meat" 
                    && testValue != "veggies" 
                    && testValue != "cheese" 
                    && testValue != "sauce")
                {
                    var exMessage = String.Format(Exceptions.InvalidToppingName, value);
                    throw new ArgumentException(exMessage);
                } 

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                // Range 1...50
                if (value < MinWeight || value > MaxWeight)
                {
                    var exMessage = String.Format(Exceptions.InvalidToppingWeight, this.type);
                    throw new ArgumentException(exMessage);
                }

                this.weight = value;
            }
        }

        public double Calories => this.CalcCalories();

        private double CalcCalories()
        {
            var correctType = this.Type.ToLower() switch
            {
                "meat" => 1.2,
                "veggies" => 0.8,
                "cheese" => 1.1,
                "sauce" => 0.9,
                _ => 0
            };

            return (2 * this.Weight) * correctType;
        }

        public override string ToString()
        {
            return $"Topping {this.Type}, Weight {this.Weight}, Calories {this.Calories:F2}";
        }
    }
}
