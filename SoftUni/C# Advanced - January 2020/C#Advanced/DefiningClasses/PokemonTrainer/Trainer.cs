using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
		private string _name;
		
		private int _badgeCount;

		private List<Pokemon> _pokemons = new List<Pokemon>();

		public Trainer(string name)
		{
			this.Name = name;
			this.BadgeCount = 0;
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int BadgeCount
		{
			get { return _badgeCount; }
			set { _badgeCount = value; }
		}

		public List<Pokemon> Pokemons		
		{
			get { return _pokemons; }
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append($"{this.Name} ");
			sb.Append($"{this.BadgeCount} ");
			sb.Append($"{this.Pokemons.Count}");

			return sb.ToString();
		}
	}
}
