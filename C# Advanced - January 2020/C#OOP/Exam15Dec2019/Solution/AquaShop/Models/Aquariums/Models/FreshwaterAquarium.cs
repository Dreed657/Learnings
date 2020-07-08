namespace AquaShop.Models.Aquariums.Models
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int INIT_CAPACITY = 50;

        public FreshwaterAquarium(string name) 
            : base(name, INIT_CAPACITY)
        {
        }
    }
}
