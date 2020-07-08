namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> Gladiators;
        
        public string Name { get; set; }

        public int Count 
        {
            get { return Gladiators.Count; }
        }
        public Arena(string name)
        {
            this.Name = name;
            this.Gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {
            Gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiators.Remove(Gladiators.Find(x => x.Name == name));
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return Gladiators.OrderByDescending(x => x.GetStatPower()).First();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return Gladiators.OrderByDescending(x => x.GetWeaponPower()).First();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return Gladiators.OrderByDescending(x => x.GetTotalPower()).First();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Count} gladiators are participating.";
        }
    }
}
