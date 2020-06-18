namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Utilities.Messages;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns = new List<IGun>();

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            return this.guns.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.guns.Remove(model);
        }
    }
}
