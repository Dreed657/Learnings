namespace MilitaryElite.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            :base (id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs => this.repairs;

        public void AddRepair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Rapairs:");
            repairs.ForEach(x => sb.AppendLine($"  {x.ToString()}"));

            return sb.ToString().Trim();
        }
    }
}
