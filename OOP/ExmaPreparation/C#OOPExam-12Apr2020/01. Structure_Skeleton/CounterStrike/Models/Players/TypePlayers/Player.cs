using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players.TypePlayers
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        public bool isAlive;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlayerName));
                }

                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlayerHealth));
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPlayerArmor));
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidGun));
                }

                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armor - points > 0)
            {
                this.Armor -= points;
            }

            else if (this.Armor - points <= 0)
            {
                while (this.Armor > 0)
                {
                    this.Armor -= 1;
                    points -= 1;
                }

                if (this.Health - points < 0)
                {
                    //this.IsAlive = false;
                    this.Health = 0;
                }

                else
                {
                    this.Health -= points;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
