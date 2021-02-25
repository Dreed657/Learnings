using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int BASE_WEIGHT = 5;

        public FirePotion()
            : base(BASE_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.TakeDamage(20);
        }
    }
}
