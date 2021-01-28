using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepositoty : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
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
