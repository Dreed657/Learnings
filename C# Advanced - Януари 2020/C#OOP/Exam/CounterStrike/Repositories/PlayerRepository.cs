namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Utilities.Messages;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players = new List<IPlayer>();

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.players.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return this.players.Remove(model);
        }
    }
}
