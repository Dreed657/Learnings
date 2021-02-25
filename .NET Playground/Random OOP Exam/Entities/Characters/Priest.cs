using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double BASE_HEALTH = 50;
        private const double BASE_ARMOR = 25;
        private const double BASE_ABILITYPOINTS = 40;

        public Priest(string name)
            : base(name, BASE_HEALTH, BASE_ARMOR, BASE_ABILITYPOINTS, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
