namespace AquaShop.Models.Fish.Models
{
    public class SaltwaterFish : Fish
    {
        private const int INIT_SIZE = 5;

        /// <summary>
        /// Can only live in SaltwaterAquarium!
        /// </summary>
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = INIT_SIZE;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
