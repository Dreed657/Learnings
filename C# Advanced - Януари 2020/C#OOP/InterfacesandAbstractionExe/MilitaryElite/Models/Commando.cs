namespace MilitaryElite.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;

    public class Commando : SpecialisedSoldier, ICommando 
    {
        private List<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string coprs)
            :base(id, firstName, lastName, salary, coprs)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission (Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            missions.ForEach(x => sb.AppendLine($"  {x.ToString()}"));

            return sb.ToString().Trim();
        }
    }
}
