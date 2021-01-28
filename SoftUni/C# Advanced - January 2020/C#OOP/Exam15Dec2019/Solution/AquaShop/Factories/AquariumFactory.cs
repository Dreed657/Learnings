namespace AquaShop.Factories
{
    using AquaShop.Factories.Contracts;
    using AquaShop.Models.Aquariums.Models;
    using AquaShop.Models.Aquariums.Contracts;

    public class AquariumFactory : IAquariumFactory
    {
        public IAquarium CreateAquarium(string aquariumType, string aquariumName)
        {
            return aquariumType switch
            {
                "FreshwaterAquarium" => new FreshwaterAquarium(aquariumName),
                "SaltwaterAquarium" => new SaltwaterAquarium(aquariumName),
                _ => null
            };
        }
    }
}
