namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;

    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base (id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"Name: {this.firstName} {this.lastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
