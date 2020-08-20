using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns.TypeGuns;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps.TypeMaps
{
    public class GunRepository : IRepository
    {
        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => models.AsReadOnly();

        public void Add(IGun gun)
        {
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            else
            {
                models.Add(gun);
            }
        }

        public bool Remove(IGun gun)
        {
            if (models.Contains(gun))
            {
                models.Remove(gun);
                return true;
            }

            return false;
        }

        public IGun FindByName(string name)
        {
            IGun gunToReturn = models.FirstOrDefault(x => x.Name == name);

            if (gunToReturn != default)
            {
                return gunToReturn;
            }

            return null;
        }
    }
}
