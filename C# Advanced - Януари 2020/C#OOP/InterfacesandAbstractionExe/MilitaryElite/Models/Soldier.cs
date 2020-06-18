namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;

    using MilitaryElite.Contracts;

    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Id { get; }

        public string firstName { get; }

        public string lastName { get; }
    }
}
