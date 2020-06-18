using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Decoration : Contracts.IDecoration
    {
        public Decoration()
        {

        }

        public Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort { get; set; }

        public decimal Price { get; set; }
    }
}
