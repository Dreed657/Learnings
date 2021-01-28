using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    public static class Aquariums : Contracts.IAquarium
    {
        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                
                this.Name = value;
            }
        }

        public int Capacity
        {
            get { return this.Capacity; }
            set { this.Capacity = value; }
        }

        public int Comfort
        {
            get { return this.Comfort; }
            private set
            {
                // Not Implemneted;
                this.Comfort = value;
            }
        }

        public ICollection<IDecoration> Decorations => throw new NotImplementedException();

        public ICollection<IFish> Fish => throw new NotImplementedException();

        public void AddDecoration(IDecoration decoration)
        {
            throw new NotImplementedException();
        }

        public void AddFish(IFish fish)
        {
            throw new NotImplementedException();
        }

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFish(IFish fish)
        {
            throw new NotImplementedException();
        }
    }
}
