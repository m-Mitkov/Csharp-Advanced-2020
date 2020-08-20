using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.TypePlayers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CounterStrike.Models.Maps.TypeMaps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terorists = new List<IPlayer>();
            List<IPlayer> counterTerorists = new List<IPlayer>();

            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Terrorist))
                {
                    terorists.Add(player);
                }

                else
                {
                    counterTerorists.Add(player);
                }
            }

            while (terorists.Any(x => x.IsAlive == true) && counterTerorists.Any(x => x.IsAlive == true))
            {
                foreach (var terorist in terorists.Where(x => x.IsAlive == true))
                {
                    IPlayer player = terorist;

                    foreach (var counterTerorist in counterTerorists.Where(x => x.IsAlive == true))
                    {
                        int attackPoints = player.Gun.Fire();

                        counterTerorist.TakeDamage(attackPoints);
                    }
                }

                foreach (var counterTerorist in counterTerorists.Where(x => x.IsAlive == true))
                {
                    IPlayer player = counterTerorist;

                    foreach (var terorist in terorists.Where(x => x.IsAlive == true))
                    {
                        int attackPoints = player.Gun.Fire();

                        terorist.TakeDamage(attackPoints);
                    }
                }
            }

            if (terorists.Any(x => x.IsAlive == true))
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
