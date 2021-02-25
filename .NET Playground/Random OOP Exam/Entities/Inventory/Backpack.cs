namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int BASE_CAPACITY = 100;

        public Backpack() 
            :base(BASE_CAPACITY)
        {
        }
    }
}
