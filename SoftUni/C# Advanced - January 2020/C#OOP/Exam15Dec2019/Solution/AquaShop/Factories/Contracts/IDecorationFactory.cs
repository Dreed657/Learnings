namespace AquaShop.Factories.Contracts
{
    using AquaShop.Models.Decorations.Contracts;

    public interface IDecorationFactory
    {
        IDecoration CreateDecoration(string decorationType);
    }
}
