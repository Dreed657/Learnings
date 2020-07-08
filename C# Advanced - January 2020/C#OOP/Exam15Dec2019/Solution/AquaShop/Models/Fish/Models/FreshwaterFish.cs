namespace AquaShop.Models.Fish.Models
{
    public class FreshwaterFish : Fish
    {
        private const int INIT_SIZE = 3;

        /// <summary>
        /// Can only live in FreshwaterAquarium!
        /// </summary>
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = INIT_SIZE;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
