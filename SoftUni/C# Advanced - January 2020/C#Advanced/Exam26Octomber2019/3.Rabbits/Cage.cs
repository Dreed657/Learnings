using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Rabbit> Data;

        public int Count { get { return this.Data.Count; } }

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Rabbit>();
        }

        public void Add(Rabbit rabbit)
        {
            if (rabbit != null && this.Data.Count < Capacity)
            {
                this.Data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = this.Data.Find(x => x.Name == name);

            if (rabbit != null)
            {
                this.Data.Remove(rabbit);
                return true;
            }
            else return false;
        }

        public void RemoveSpecies(string species)
        {
            var rabbits = this.Data.FindAll(x => x.Species == species);

            if (rabbits.Count > 0)
            {
                this.Data.RemoveAll(x => x.Species == species);
            }
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.Data.Find(x => x.Name == name);

            if (rabbit != null)
            {
                rabbit.Available = false;
                return rabbit;
            }
            else return null;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = this.Data.FindAll(x => x.Species == species);

            if (rabbits.Count > 0)
            {
                rabbits.ForEach(x => x.Available = false);
                return rabbits.ToArray();
            }
            else return null;
        }

        public string Report()
        {
            var rabbits = this.Data.Where(x => x.Available == true).ToList();
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            rabbits.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().Trim();
        }
    }
}
