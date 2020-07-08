using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Tire
    {
		private double _age;

		public double Age
		{
			get { return _age; }
			set { _age = value; }
		}

		private double _pressure;

		public double Pressure
		{
			get { return _pressure; }
			set { _pressure = value; }
		}

		public Tire(double pressure, double age)
		{
			this.Age = age;
			this.Pressure = pressure;
		}
	}
}
