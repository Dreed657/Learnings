using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
		private string _model;

		private double _fuelAmount;
		
		private double _fuelConsumptionPerKilometer;

		private double _travelledDistance = 0;
		
		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

		public double FuelAmount
		{
			get { return _fuelAmount; }
			set { _fuelAmount = value; }
		}

		public double FuelConsumptionPerKilometer
		{
			get { return _fuelConsumptionPerKilometer; }
			set { _fuelConsumptionPerKilometer = value; }
		}

		public double TravelledDistance
		{
			get { return _travelledDistance; }
			set { _travelledDistance = value; }
		}

		private Engine _engine;

		public Engine Engine
		{
			get { return _engine; }
			set { _engine = value; }
		}

		private Cargo _cargo;

		public Cargo Cargo
		{
			get { return _cargo; }
			set { _cargo = value; }
		}

		private List<Tire> _tires;

		public List<Tire> Tires
		{
			get { return _tires; }
			set { _tires = value; }
		}

		public Car(string model, double fuelAmount, double fuelConsultionPerKm)
		{
			this.Model = model;
			this.FuelAmount = fuelAmount;
			this.FuelConsumptionPerKilometer = fuelConsultionPerKm;
			this.TravelledDistance = 0;
		}

		public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
		{
			this.Model = model;
			this.Engine = engine;
			this.Cargo = cargo;
			this.Tires = tires;
		}

		public void canDrive(double amountOfKm)
		{
			double fuelNeeded = amountOfKm * this.FuelConsumptionPerKilometer;
			bool canTravel = this.FuelAmount - fuelNeeded >= 0;

			if (canTravel)
			{
				this.TravelledDistance += amountOfKm;
				this.FuelAmount -= fuelNeeded;
			}
			else Console.WriteLine("Insufficient fuel for the drive");
		}

		public override string ToString()
		{
			return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
		}
	}
}
