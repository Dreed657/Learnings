namespace AquaShop.Models.Decorations.Models
{
    public class Plant : Decoration
    {
        private const int DEF_COMFORT = 5;
        private const decimal DEF_PRICE = 10;

        public int Id { get; set; }

        public Plant()
            : base(DEF_COMFORT, DEF_PRICE)
        {
        }
    }
}
