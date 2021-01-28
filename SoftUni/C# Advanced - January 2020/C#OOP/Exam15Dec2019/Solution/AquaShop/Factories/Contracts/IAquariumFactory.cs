namespace AquaShop.Factories.Contracts
{
    using AquaShop.Models.Aquariums.Contracts;

    public interface IAquariumFactory
    {
        IAquarium CreateAquarium(string aquariumType, string aquariumName);
    }
}
