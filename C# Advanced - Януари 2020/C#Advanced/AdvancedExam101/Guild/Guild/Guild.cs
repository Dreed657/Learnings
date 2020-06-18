namespace Guild
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Guild
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        private List<Player> roster { get; set; }

        public int Count { get { return this.roster.Count; } }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = this.roster.Find(x => x.Name == name);
            if (this.roster.Contains(player))
            {
                this.roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            var player = this.roster.Find(x => x.Name == name);
            if (this.roster.Contains(player))
            {
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.roster.Find(x => x.Name == name);
            if (this.roster.Contains(player))
            {
                if (player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string className) 
        {
            var players = this.roster.Where(x => x.Class == className).ToArray();

            if (players.Length > 0)
            {
                foreach (var player in players)
                {
                    this.roster.Remove(player);
                }
                return players;
            }
            return null;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            this.roster.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().Trim();
        }
    }
}
