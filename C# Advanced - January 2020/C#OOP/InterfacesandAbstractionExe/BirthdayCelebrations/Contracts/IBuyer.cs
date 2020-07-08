namespace BirthdayCelebrations.Contracts
{
    public interface IBuyer : INameble
    {
        int Food { get; set; }

        void BuyFood();
    }
}
