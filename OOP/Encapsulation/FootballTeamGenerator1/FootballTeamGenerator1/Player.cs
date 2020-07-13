using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator1
{
    public class Player
    {
        private Dictionary<string, int> statistic;
        private string name;

        public Player(string name, params int[] stats)
        {
            this.Name = name;
            this.statistic = new Dictionary<string, int>();
            TemplateStats();
            FillStatsPlayer(stats);
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public double Stats => this.statistic.Sum(x => (double)x.Value)/ this.statistic.Count;

        private void TemplateStats()
        {
            this.statistic.Add("Endurance", 0);
            this.statistic.Add("Sprint", 0);
            this.statistic.Add("Dribble", 0);
            this.statistic.Add("Passing", 0);
            this.statistic.Add("Shooting", 0);
        }

        private void FillStatsPlayer(params int[] stats)
        {
            this.statistic["Endurance"] = stats[0];
            this.statistic["Sprint"] = stats[1];
            this.statistic["Dribble"] = stats[2];
            this.statistic["Passing"] = stats[3];
            this.statistic["Shooting"] = stats[4];

            if (statistic.Any(x => x.Value < 0 || x.Value > 100))
            {
                var invalidStatistic = statistic.First((x => x.Value < 0 || x.Value > 100));

                throw new Exception($"{invalidStatistic.Key} should be between 0 and 100.");
            }
        }
    }
}
