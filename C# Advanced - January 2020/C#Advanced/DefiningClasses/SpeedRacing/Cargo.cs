using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Cargo
    {
		private string _cargoType;

		public string CargoType
		{
			get { return _cargoType; }
			set { _cargoType = value; }
		}

		private double _cargoWeight;

		public double CargoWeight
		{
			get { return _cargoWeight; }
			set { _cargoWeight = value; }
		}

		public Cargo(double cargoWeight, string cargoType)
		{
			this.CargoType = cargoType;
			this.CargoWeight = cargoWeight;
		}
	}
}
