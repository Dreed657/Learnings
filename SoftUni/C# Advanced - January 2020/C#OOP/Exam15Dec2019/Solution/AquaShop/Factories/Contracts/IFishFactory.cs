namespace AquaShop.Factories.Contracts
{
    using AquaShop.Models.Fish.Contracts;

    public interface IFishFactory
    {
        IFish CreateFish(string fishType, string fishName, string fishSpeecies, decimal price);
    }
}
