using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Child
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = 3;
        }

        void Eat()
        {
            this.Size += 3;
        }
    }
}
