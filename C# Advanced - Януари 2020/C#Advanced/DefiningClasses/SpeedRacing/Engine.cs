using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Engine
    {
		private double _speed;

		public double Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}

		private double _power;

		public double Power
		{
			get { return _power; }
			set { _power = value; }
		}

		public Engine(double speed, double power)
		{
			this.Speed = speed;
			this.Power = power;
		}
	}
}
