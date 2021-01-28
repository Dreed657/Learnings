namespace MilitaryElite.Models
{
    using System;

    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            :base (id, firstName, lastName, salary)
        {
            this.corps = corps switch
            {
                "Airforces" => Corps.Airforces,
                "Marines" => Corps.Marines,
                _ => throw new Exception("Invalid Corps")
            };
        }

        public Corps Corps => this.corps;
    }
}
