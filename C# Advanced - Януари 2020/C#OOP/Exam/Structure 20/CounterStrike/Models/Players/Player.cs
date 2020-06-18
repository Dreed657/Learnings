using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get => this.username;
            private set=> this.username = value;
        }

        public int Health
        {
            get => this.health;
            private set => this.health = value;
        }

        public int Armor
        {
            get => this.armor;
            private set => this.armor = value;
        }

        public IGun Gun
        {
            get => this.gun;
            private set => this.gun = value;
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            var doSOmetinh = 092;
        }
    }
}
