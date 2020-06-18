using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Child
{
    public class SaltwaterFish : Fish
    {
        public SaltwaterFish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = 5;
        }

        void Eat()
        {
            this.Size += 2;
        }
    }
}
