using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
		private string _model;

		private int _power;

		private double _displacement;

		private string _efficiency;

		public Engine(string model, int power)
		{
			this.Model = model;
			this.Power = power;
		}

		public Engine(string model, int power, double displacement)
		: this(model, power)
		{
			this.Displacement = displacement;
		}

		public Engine(string model, int power, string efficiency)
			: this(model, power)
		{
			this.Efficiency = efficiency;
		}

		public Engine(string model, int power, double displacement, string efficiency)
			: this(model, power)
		{
			this.Displacement = displacement;
			this.Efficiency = efficiency;
		}

		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

		public int Power
		{
			get { return _power; }
			set { _power = value; }
		}

		public double Displacement
		{
			get { return _displacement; }
			set { _displacement = value; }
		}

		public string Efficiency
		{
			get { return _efficiency; }
			set { _efficiency = value; }
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			var empty = "n/a";

			var displacement = this.Displacement == 0 ? empty : this.Displacement.ToString();
			var efficiency = this.Efficiency == null ? empty : this.Efficiency;

			sb.Append($"{this.Model}:\n");
			sb.Append($"  Power: {this.Power}\n");
			if (displacement != null) sb.Append($"  Displacement: {displacement}\n");
			if (efficiency != null) sb.Append($"  Efficiency: {efficiency}\n");

			return sb.ToString();
		}
	}
}
