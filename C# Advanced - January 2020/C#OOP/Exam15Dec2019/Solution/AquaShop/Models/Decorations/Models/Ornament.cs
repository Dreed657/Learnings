namespace AquaShop.Models.Decorations.Models
{
    public class Ornament : Decoration
    {
        private const int DEF_COMFORT = 1;
        private const decimal DEF_PRICE = 5;

        public Ornament() 
            : base(DEF_COMFORT, DEF_PRICE)
        {
        }
    }
}
