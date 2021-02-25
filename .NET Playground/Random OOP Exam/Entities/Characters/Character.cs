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
                if (value > 0 && value <= this.BaseHealth)
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
                if (value > 0)
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
            if (this.IsAlive)
            {
                if (this.Armor > 0)
                {
                    var armor = this.Armor;

                    if (armor - hitPoints < 0)
                    {
                        hitPoints = Math.Abs(hitPoints);
                    }
                    else
                    {
                        this.Armor -= hitPoints;
                    }

                    if (hitPoints > 0)
                    {
                        this.Health -= hitPoints;
                    }
                }

                if (this.Health < 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}