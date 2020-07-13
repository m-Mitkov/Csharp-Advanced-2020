using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator1
{
    public class TeamsCollection
    {
        private List<Team> teams;

        public TeamsCollection()
        {
            this.teams = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            this.teams.Add(team);
        }

        public Team ReturnTeam(string name)
        {
            if (this.teams.Any(x => x.TeamName == name))
            {
                return this.teams.First(x => x.TeamName == name);
            }

            throw new Exception($"Team {name} does not exist.");
        }
    }
}
