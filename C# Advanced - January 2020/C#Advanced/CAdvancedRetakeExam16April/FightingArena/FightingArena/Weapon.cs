namespace FightingArena
{
    public class Weapon
    {
		private int _size;
		private int _solidity;
		private int _sharpness;

		public int Size
		{
			get { return _size; }
			set { _size = value; }
		}

		public int Solidity
		{
			get { return _solidity; }
			set { _solidity = value; }
		}

		public int Sharpness
		{
			get { return _sharpness; }
			set { _sharpness = value; }
		}

		public Weapon(int size, int solidity, int sharpness)
		{
			this.Size = size;
			this.Solidity = solidity;
			this.Sharpness = sharpness;
		}

		public int Power()
		{
			return this.Size + this.Solidity + this.Sharpness;
		}
	}
}
