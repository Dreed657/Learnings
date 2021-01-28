namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public double Calories => this.CalcCalories();

        public Dough(string flourType, string bakeType, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakeType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set 
            { 
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(Exceptions.InvalidDough);
                }

                this.flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(Exceptions.InvalidDough);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(Exceptions.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        private double CalcCalories()
        {
            var flourModifier = this.FlourType.ToLower() switch
            {
                "white" => 1.5,
                "wholegrain" => 1.0,
                _ => 0
            };

            var bakeModifier = this.BakingTechnique.ToLower() switch
            {
                "crispy" => 0.9,
                "chewy" => 1.1,
                "homemade" => 1.0,
                _ => 0
            };

            return (2 * this.Weight) * flourModifier * bakeModifier;
        }

        public override string ToString()
        {
            return $"Flour: {this.FlourType}, Baking {this.BakingTechnique}, Weight {this.Weight}, Cal {this.Calories:F2}.";
        }
    }
}
