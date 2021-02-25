using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double BASE_HEALTH = 100;
        private const double BASE_ARMOR = 50;
        private const double BASE_ABILITYPOINTS = 40;

        public Warrior(string name)
            : base(name, BASE_HEALTH, BASE_ARMOR, BASE_ABILITYPOINTS, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (character.Name == this.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
