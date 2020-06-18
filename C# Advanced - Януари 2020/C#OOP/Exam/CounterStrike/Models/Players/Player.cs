namespace CounterStrike.Models.Players
{
    using System;
    using System.Text;

    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Utilities.Messages;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        private bool isAlive;

        protected Player(string name, int health, int armor, IGun gun)
        {
            this.Username = name;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
            this.IsAlive = true;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                if (value  == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive 
        { 
            get => this.isAlive; 
            private set => this.isAlive = value; 
        }

        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                if (this.Armor < points)
                {
                    points -= this.Armor;
                    this.Armor -= 0;
                }
                else
                {
                    this.Armor -= points;
                    points = 0;
                }
            }

            if (this.Health - points <= 0)
            {
                this.IsAlive = false;
                this.Health = 0;
            }
            else this.Health -= points;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
