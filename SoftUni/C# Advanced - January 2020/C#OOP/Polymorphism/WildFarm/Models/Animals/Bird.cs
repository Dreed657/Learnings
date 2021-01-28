namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize)
            :base (name, weight)
        {
            this.wingSize = wingSize;
        }

        public double WingSize
        {
            get => this.wingSize;
            set => this.wingSize = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
