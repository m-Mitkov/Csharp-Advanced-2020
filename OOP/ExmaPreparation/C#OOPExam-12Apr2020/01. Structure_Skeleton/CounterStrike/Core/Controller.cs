using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns.TypeGuns;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Maps.TypeMaps;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.TypePlayers;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        /// <summary>
        /// keep eye on IMap!
        /// </summary>

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type == nameof(Pistol) || type == nameof(Rifle))
            {
                IGun gun;
                if (type == nameof(Pistol))
                {
                    gun = new Pistol(name, bulletsCount);
                    guns.Add(gun);
                }

                else
                {
                    gun = new Rifle(name, bulletsCount);
                    guns.Add(gun);
                }

                return String.Format(OutputMessages.SuccessfullyAddedGun, name);
            }

            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidGunType));
            }
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if (type == nameof(Terrorist) || type == nameof(CounterTerrorist))
            {
                IPlayer player;
                IGun gun;

                gun = guns.FindByName(gunName);

                if (type == nameof(Terrorist))
                {
                    if (gun == null)
                    {
                        throw new ArgumentException(String.Format(ExceptionMessages.GunCannotBeFound));
                    }

                    else
                    {
                        player = new Terrorist(username, health, armor, gun);
                        players.Add(player);
                    }
                }

                else
                {
                    if (gun == null)
                    {
                        throw new ArgumentException(String.Format(ExceptionMessages.GunCannotBeFound));
                    }

                    else
                    {
                        player = new CounterTerrorist(username, health, armor, gun);
                        players.Add(player);
                    }
                }

                return String.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
            }

            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlayerType));
            }
        }

        public string Report()
        {
            List<IPlayer> orderedPlayers = players.Models.OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
           return map.Start(players.Models.ToArray());
        }
    }
}
