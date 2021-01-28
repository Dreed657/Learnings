namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Car
    {
        private string _make;
        private string _model;
        private int _horsePower;
        private string _regNumber;
        
        public Car(string make, string model, int hp, string plate)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = hp;
            this.RegistrationNumber = plate;
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int HorsePower
        {
            get { return _horsePower; }
            set { _horsePower = value; }
        }

        public string RegistrationNumber
        {
            get { return _regNumber; }
            set { _regNumber = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Make: {this.Make}\n");
            sb.Append($"Model: {this.Model}\n");
            sb.Append($"HorsePower: {this.HorsePower}\n");
            sb.Append($"RegistrationNumber: {this.RegistrationNumber}");

            return sb.ToString();
        }
    }
}
