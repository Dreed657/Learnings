using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
		private string _model;
		private Engine _engine;
		private double _weight;
		private string _color;

		public Car(string model, Engine engine)
		{
			this.Model = model;
			this.Engine = engine;
		}

		public Car(string model, Engine engine, double weight)
			: this(model, engine)
		{
			this.Weight = weight;
		}

		public Car(string model, Engine engine, string color)
			: this(model, engine)
		{
			this.Color = color;
		}

		public Car(string model, Engine engine, double weight, string color)
			: this(model, engine)
		{
			this.Weight = weight;
			this.Color = color;
		}

		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

		public Engine Engine
		{
			get { return _engine; }
			set { _engine = value; }
		}

		public double Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		public string Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			var empty = "n/a";

			var weight = this.Weight == 0 ? empty : this.Weight.ToString();
			var color = this.Color == null ? empty : this.Color;

			sb.Append($"{this.Model}:\n");
			sb.Append($"  {this.Engine.ToString()}");
			if (weight != null) sb.Append($"  Weight: {weight}\n");
			if (color != null) sb.Append($"  Color: {color}");

			return string.Join(Environment.NewLine, sb);
		}
	}
}
