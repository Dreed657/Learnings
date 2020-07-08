namespace AquaShop.Models.Aquariums.Models
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int INIT_CAPACITY = 25;

        public SaltwaterAquarium(string name) 
            : base(name, INIT_CAPACITY)
        {
        }
    }
}
