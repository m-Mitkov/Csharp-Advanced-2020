using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator1
{
    public class Team
    {
        private List<Player> players;
        private string teamName;

        public Team(string name)
        {
            this.TeamName = name;
            this.players = new List<Player>();
        }

        public string TeamName
        {
            get => this.teamName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.teamName = value;
            }
        }
        public double Rating => this.players.Count != 0
            ? Math.Round(players.Sum(x => x.Stats) / this.players.Count)
            : 0;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (this.players.Any(x => x.Name == name))
            {
                var playerToRemove = this.players.First(x => x.Name == name);
                this.players.Remove(playerToRemove);
                //this.Rating = Math.Round(players.Sum(x => x.Stats) / this.players.Count); 
                return;
            }

            throw new Exception($"Player {name} is not in {this.TeamName} team.");
        }
    }
}
