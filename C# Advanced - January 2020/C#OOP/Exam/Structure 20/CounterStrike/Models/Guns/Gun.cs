using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bullets;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bullets;
            private set
            {
                this.bullets = value;
            }
        }

        public abstract int Fire();
    }
}
