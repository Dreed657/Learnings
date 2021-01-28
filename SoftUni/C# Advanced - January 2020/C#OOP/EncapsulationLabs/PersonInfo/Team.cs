using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name
        {
            get { return this.name; } 
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot contain fewer than 3 symbols!");
                }

                this.name = value;
            }
        }

        public IReadOnlyList<Person> FirstTeam { get { return this.firstTeam; } }

        public IReadOnlyList<Person> ReserveTeam { get { return this.reserveTeam; } }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40) firstTeam.Add(person);
            else reserveTeam.Add(person);
        }

    }
}
