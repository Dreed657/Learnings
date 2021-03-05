using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string _name;
        private double _health;
        private double _armor;
        
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.BaseArmor = armor;
            this.BaseHealth = health;

            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this._name = value;
            }
        }

        public double Health
        {
            get => this._health;
            set
            {
                if (value >= 0 && value <= this.BaseHealth)
                {
                    this._health = value;
                }
            }
        }

        public double Armor
        {
            get => this._armor;
            set
            {
                if (value >= 0)
                {
                    this._armor = value;
                }
            }
        }

        public double AbilityPoints { get; protected set; }

        public double BaseHealth { get; protected set; }

        public double BaseArmor { get; protected set; }

        public Bag Bag { get; protected set; }

		public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var hitPointsLeft = hitPoints;

            if (this.Armor > 0)
            {
                if (this.Armor <= hitPoints)
                {
                    hitPointsLeft = Math.Abs(this.Armor - hitPoints);
                    this.Armor = 0;
                }
                else
                {
                    this.Armor -= hitPoints;
                    hitPointsLeft = 0;
                }
            }

            if (hitPointsLeft > 0)
            {
                if (this.Health - hitPointsLeft > 0)
                {
                    this.Health -= hitPointsLeft;
                }
                else
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            return string.Format(SuccessMessages.CharacterStats, this.Name, this.Health, this.BaseHealth, this.Armor, this.BaseArmor, this.IsAlive ? "Alive" : "Dead");
        }
    }
}