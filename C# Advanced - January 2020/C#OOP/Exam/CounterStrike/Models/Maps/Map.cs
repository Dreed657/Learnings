namespace CounterStrike.Models.Maps
{
    using System.Linq;
    using System.Collections.Generic;

    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new Queue<IPlayer>(players.Where(x => x.GetType().Name == nameof(Terrorist)).ToList());
            var counterTerrorists = new Queue<IPlayer>(players.Where(x => x.GetType().Name == nameof(CounterTerrorist)).ToList());

            //Until one team have no live players
            //T Attack first;
            //Each alive T shoots each CT 
            //CT take dmg equal to T shots fired
            //Repeat for CT Attack

            bool anyOneAlive = terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive);

            while (anyOneAlive)
            {
                //T Round
                foreach (var T in terrorists)
                {
                    var CT = counterTerrorists.Dequeue();

                    var damage = T.Gun.Fire();

                    //if (CT.Health >= damage)
                    //{
                       
                    //}

                    CT.TakeDamage(damage);

                    counterTerrorists.Enqueue(CT);
                }

                if (!counterTerrorists.Any(x => x.IsAlive)) break;

                //CT Round
                foreach (var CT in counterTerrorists)
                {
                    var T = terrorists.Dequeue();

                    var damage = CT.Gun.Fire();

                    //if (T.Health >= damage)
                    //{
                    //    
                    //}

                    T.TakeDamage(damage);

                    terrorists.Enqueue(T);
                }

                if (!terrorists.Any(x => x.IsAlive)) break;
            }

            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}
