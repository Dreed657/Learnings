namespace AquaShop.Models.Decorations.Models
{
    using AquaShop.Models.Decorations.Contracts;

    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort
        {
            get => this.comfort;
            private set => this.comfort = value;
        }

        public decimal Price
        {
            get => this.price;
            private set => this.price = value;
        }
    }
}
