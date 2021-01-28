namespace AquaShop.Factories
{
    using AquaShop.Factories.Contracts;
    using AquaShop.Models.Decorations.Models;
    using AquaShop.Models.Decorations.Contracts;

    public class DecorationFactory : IDecorationFactory
    {
        public IDecoration CreateDecoration(string decorationType)
        {
            return decorationType switch
            {
                "Plant" => new Plant(),
                "Ornament" => new Ornament(),
                _ => null
            };
        }
    }
}
