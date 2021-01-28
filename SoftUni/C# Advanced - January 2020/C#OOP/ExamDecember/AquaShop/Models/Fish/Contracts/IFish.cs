namespace AquaShop.Models.Fish.Contracts
{
    using System;

    public interface IFish
    {
        string Name { get; }

        string Species { get; }

        int Size { get; }

        decimal Price { get; }

        abstract void Eat();
    }
}
