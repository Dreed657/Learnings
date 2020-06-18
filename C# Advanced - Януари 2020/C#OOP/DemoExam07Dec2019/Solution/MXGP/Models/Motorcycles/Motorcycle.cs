namespace MXGP.Models.Motorcycles
{
    using System;

    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsepower;
        private int MIN_HP;
        private int MAX_HP;
         
        protected Motorcycle(string model, int horsePower, double cubicCentimeters, int MIN_HP, int MAX_HP)
        {
            this.MIN_HP = MIN_HP;
            this.MAX_HP = MAX_HP;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsepower;
            private set
            {
                if (value < MIN_HP || value > MAX_HP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsepower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
