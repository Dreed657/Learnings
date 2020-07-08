namespace CounterStrike.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IGun> gunRepo;
        private IRepository<IPlayer> playerRepo;
        private IMap map;

        public Controller()
        {
            this.gunRepo = new GunRepository();
            this.playerRepo = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = type switch
            {
                nameof(Pistol) => new Pistol(name, bulletsCount),
                nameof(Rifle) => new Rifle(name, bulletsCount),
                _ => null
            };

            if (gun == null) throw new ArgumentException(ExceptionMessages.InvalidGunType);
            this.gunRepo.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.gunRepo.FindByName(gunName);

            if (gun == null) throw new ArgumentException(ExceptionMessages.GunCannotBeFound);

            IPlayer player = type switch
            {
                nameof(Terrorist) => new Terrorist(username, health, armor, gun),
                nameof(CounterTerrorist) => new CounterTerrorist(username, health, armor, gun),
                _ => null
            };

            if (player == null) throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            this.playerRepo.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var item in this.playerRepo.Models.OrderBy(x => x.GetType().Name).ThenBy(x => x.Username))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            return this.map.Start(this.playerRepo.Models.ToList());
        }
    }
}
