using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class Fish : Contracts.IFish
    {
        public Fish()
        {

        }

        public Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name 
        {   
            get { return this.Name; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }

                this.Name = value;
            }
        }

        public string Species 
        {
            get { return this.Species; }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                this.Species = value;
            }
        }

        public int Size { get; set; }

        public decimal Price 
        { 
            get { return this.Price; }
            set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                this.Price = value;
            }
        }

        public void Eat()
        {
            this.Size++;
        }
    }
}
