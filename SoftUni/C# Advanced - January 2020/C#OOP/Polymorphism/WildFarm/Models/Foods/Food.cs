namespace WildFarm.Models.Foods
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get => this.quantity;
            set => this.quantity = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - {this.Quantity}";
        }
    }
}
