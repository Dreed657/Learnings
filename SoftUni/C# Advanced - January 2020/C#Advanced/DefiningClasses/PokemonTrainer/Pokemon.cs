using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
		private string _name;
		
		private string _element;

		private double _health;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Element
		{
			get { return _element; }
			set { _element = value; }
		}

		public double Health
		{
			get { return _health; }
			set { _health = value; }
		}

		public Pokemon(string name, string element, double health)
		{
			this.Name = name;
			this.Element = element;
			this.Health = health;
		}
		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append($"{this.Name} ");
			sb.Append($"{this.Element} ");
			sb.Append($"{this.Health}");

			return sb.ToString();
		}
	}
}
