
namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int BASE_CAPACITY = 25;

        public Satchel()
            :base(BASE_CAPACITY)
        {
        }
    }
}
