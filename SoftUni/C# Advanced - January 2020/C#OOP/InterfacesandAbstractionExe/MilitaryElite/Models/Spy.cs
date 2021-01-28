namespace MilitaryElite.Models
{
    using System.Text;

    using MilitaryElite.Contracts;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int code)
            : base(id, firstName, lastName)
        {
            this.Code = code;
        }
        
        public int Code { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.lastName} {this.lastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.Code}");

            return sb.ToString().Trim();
        }
    }
}
