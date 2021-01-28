namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model) => races.Add(model);

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRace model) => this.races.Remove(model);
        
    }
}
