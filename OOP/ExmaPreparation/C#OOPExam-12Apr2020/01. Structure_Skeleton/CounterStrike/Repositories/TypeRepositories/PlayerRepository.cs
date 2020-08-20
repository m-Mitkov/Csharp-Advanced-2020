using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps.TypeMaps
{
    public class PlayerRepository : IRepository
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            else
            {
                models.Add(player);
            }
        }

        public bool Remove(IPlayer player)
        {
            if (models.Contains(player))
            {
                models.Remove(player);
                return true;
            }

            return false;
        }

        public IPlayer FindByName(string name)
        {
            IPlayer gunToReturn = models.FirstOrDefault(x => x.Username == name);

            if (gunToReturn != default)
            {
                return gunToReturn;
            }

            return null;
        }
    }
}
