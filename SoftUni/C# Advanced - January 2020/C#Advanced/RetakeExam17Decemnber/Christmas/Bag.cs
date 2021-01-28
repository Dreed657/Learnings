using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Christmas
{
    public class Bag
    {
        public string Color { get; set; }

        public int Capacity { get; set; }

        public List<Present> Data { get; set; }

        public int Count 
        { 
            get 
            {
                return this.Data.Count;
            } 
        }
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.Data = new List<Present>();
        }

        public void Add(Present present)
        {
            if (this.Data.Count < this.Capacity && !this.Data.Contains(present))
            {
                Data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var wantedPresent = this.Data.Find(x => x.Name == name);

            if (wantedPresent != null)
            {
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            return Data.OrderByDescending(x => x.Weight).First();
        }

        public Present GetPresent(string name)
        {
            var wantedPresent = this.Data.Find(x => x.Name == name);
            
            if (wantedPresent != null)
            {
                return wantedPresent;
            }

            return null;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            if (this.Data.Any())
            {
                sb.AppendLine($"{this.Color} bag contains:");
                Data.ForEach(x => sb.AppendLine(x.ToString()));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
