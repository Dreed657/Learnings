namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;

    using MilitaryElite.Models;

    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
