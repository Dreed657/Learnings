namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Parking
    {
        private List<Car> _cars;
        private int _capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public int Count
        {
            get { return Cars.Count; }
        }

        public string AddCar(Car car)
        {
            string message = string.Empty;

            if (Cars.Contains(car))
            {
                message = "Car with that registration number, already exists!";
            }
            else
            {
                if (Cars.Count >= Capacity) Console.WriteLine("Parking is full!");
                else
                {
                    Cars.Add(car);
                    message = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }

            return message;
        }

        public string RemoveCar(string RegistrationNumber)
        {
            var car = Cars.Find(x => x.RegistrationNumber == RegistrationNumber);
            string message = string.Empty;

            if (car == null)
            {
                message = "Car with that registration number, doesn't exist!";
            }
            else 
            {
                Cars.Remove(car);
                message = $"Successfully removed {car.RegistrationNumber}";
            }

            return message;
        }

        public Car GetCar(string RegistrationNumber)
        {
            return Cars.Find(x => x.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            RegistrationNumbers.ForEach(car => RemoveCar(car));
        }
    }
}
