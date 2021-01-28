namespace MilitaryElite.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using MilitaryElite.Contracts;

    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base (id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates;

        public void AddPrivate(Private privateSoldier)
        {
            privates.Add(privateSoldier);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.firstName} {this.lastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");

            privates.ForEach(x => sb.AppendLine($"  {x.ToString()}"));

            return sb.ToString().Trim();
        }
    }
}
