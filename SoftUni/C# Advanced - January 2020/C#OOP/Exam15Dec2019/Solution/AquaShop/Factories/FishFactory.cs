namespace AquaShop.Factories
{
    using AquaShop.Factories.Contracts;
    using AquaShop.Models.Fish.Models;
    using AquaShop.Models.Fish.Contracts;

    public class FishFactory : IFishFactory
    {
        public IFish CreateFish(string fishType, string fishName, string fishSpeecies, decimal price)
        {
            return fishType switch
            {
                "FreshwaterFish" => new FreshwaterFish(fishName, fishSpeecies, price),
                "SaltwaterFish" => new SaltwaterFish(fishName, fishSpeecies, price),
                _ => null
            };
        }
    }
}
