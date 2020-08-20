using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns.TypeGuns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bullestCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidGun));
                }

                this.name = value;
            }
        }

        public int BulletsCount
        {
            get { return this.bullestCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidGunBulletsCount));
                }

                this.bullestCount = value;
            }
        }

        public abstract int Fire();
    }
}
